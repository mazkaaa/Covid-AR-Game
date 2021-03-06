﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text coinValueText, coinValueTextGameover, scoreValueText, scoreValueTextGameover;

    [SerializeField] private Coin coinAPI;

    [SerializeField] private GameObject[] enemySpawner;
    [SerializeField] private GameObject enemyObject;

    [SerializeField] private Player player;

    [SerializeField] private bool gameStarted = false, currentWave = false;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private int enemyWave = 0, enemyCount = 0;

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private MenuHandler menuHandler;

    [SerializeField] private AudioClip virusAudio;

    [Range(1.0f, 7.0f)]
    [SerializeField] private float waveHitboxRadius;
    [SerializeField] private float virusSpeed;
    [SerializeField] private float virusHealth;


    public GameObject damageIndicator; //<--Assign in inspector.
    public float damageDuration = 0.1f; //<--Show canvas for this duration each hit.
    // Start is called before the first frame update
    void Start()
    {
        //this.gameStarted = true;
        Time.timeScale = 0;
        this.menuHandler.openTutorScreen();
        HideDamageIndicator();

        this.virusHealth = 5.0f;
        this.virusSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameStarted) {
            this.detectNoHealth();
            this.spawnerHandler();
        }
        this.coinValueText.text = this.coinAPI.getCurrentCoin().ToString();
        this.scoreValueText.text = this.scoreManager.getScore().ToString();
        this.coinValueTextGameover.text = "Collected Coin: " + this.coinAPI.getCurrentCoin().ToString();
        this.scoreValueTextGameover.text = "Score: " + this.scoreManager.getScore().ToString();
    }

    private void detectNoHealth() {
        if (player.getCurrentHealth() < 0.1) {
            this.setGameOver();
        }
    }
    private void spawnerHandler() {
        int chance = Random.Range(0, 100);
        if (chance > 98) {
            if (this.enemyCount <= this.enemySpawner.Length) {
                this.setRandomSpawnEnemy();
            }
        }

    }

    /// <summary>
    /// Randomly spawn enemy enemySpawner gameobject. dont use this function without delaying the function.
    /// </summary>
    public void setRandomSpawnEnemy() {
        GameObject virusClone = Instantiate(enemyObject, enemySpawner[Random.Range(0, enemySpawner.Length)].transform);
        virusClone.transform.parent = null;
        virusClone.GetComponent<Enemy>().setVirusSpeed(this.virusSpeed);
        virusClone.GetComponent<Enemy>().setVirusHealth(this.virusHealth);
        virusClone.GetComponent<Enemy>().coinAPI = gameObject.GetComponent<Coin>();
        virusClone.GetComponent<Enemy>().weapon = gameObject.GetComponent<Weapon>();
        virusClone.GetComponent<Enemy>().playerAPI = gameObject.GetComponent<Player>();
        virusClone.GetComponent<Enemy>().playerObject = playerObject;
        virusClone.GetComponent<Enemy>().gameHandler = this;
        virusClone.GetComponent<Enemy>().scoreManager = gameObject.GetComponent<ScoreManager>();
        virusClone.GetComponent<Enemy>().audioSource = virusClone.GetComponent<AudioSource>();
        virusClone.GetComponent<Enemy>().audioSource.clip = this.virusAudio;
        virusClone.GetComponent<Enemy>().audioSource = GetComponent<AudioSource>();
        this.enemyCount++;
    }

    public void increaseVirusDiff(){
        this.virusSpeed = this.virusSpeed + Random.Range(0.1f, 0.6f);
        this.virusHealth = this.virusHealth + Random.Range(1.0f, 2.6f);
    }

    /// <summary>
    /// Set the game status value, like started or paused.
    /// </summary>
    public void setGameStarted(bool value) {
        this.gameStarted = value;
        this.setTheTimeScale(value);
    }

    private void setTheTimeScale(bool value){
        if (value){
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Getting game status value, like paused or not.
    /// </summary>
    public bool getGameStatus() {
        return this.gameStarted;
    }

    public void setGameOver(){
        this.setGameStarted(false);
        this.menuHandler.gameoverScreen();
        this.scoreManager.saveToLeaderboard();
        this.HideDamageIndicator();
        this.coinAPI.addTotalSavedCoin(this.coinAPI.getCurrentCoin());
    }

    public void takeVirusCount() {
        this.enemyCount--;
    }

    public void HitPlayer(){
        ShowDamageIndicator();
        CancelInvoke("HideDamageIndicator"); //<--Resets timer if hit before indicator is hidden.
        Invoke("HideDamageIndicator", damageDuration);
    }
 
    public void ShowDamageIndicator(){
        damageIndicator.SetActive(true);
    }
 
    public void HideDamageIndicator(){
        damageIndicator.SetActive(false);
    }
}
