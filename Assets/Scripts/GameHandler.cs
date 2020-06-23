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
    // Start is called before the first frame update
    void Start()
    {
        //this.gameStarted = true;
        Time.timeScale = 0;
        this.menuHandler.openTutorScreen();
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
            if (this.enemyCount < this.enemySpawner.Length) {
                this.setRandomSpawnEnemy();
                this.enemyCount++;
            }
        }

    }

    /// <summary>
    /// Randomly spawn enemy enemySpawner gameobject. dont use this function without delaying the function.
    /// </summary>
    public void setRandomSpawnEnemy() {
        GameObject virusClone = Instantiate(enemyObject, enemySpawner[Random.Range(0, enemySpawner.Length)].transform);
        virusClone.transform.parent = null;
        virusClone.GetComponent<Enemy>().setVirusHealth(5);
        virusClone.GetComponent<Enemy>().coinAPI = gameObject.GetComponent<Coin>();
        virusClone.GetComponent<Enemy>().weapon = gameObject.GetComponent<Weapon>();
        virusClone.GetComponent<Enemy>().playerAPI = gameObject.GetComponent<Player>();
        virusClone.GetComponent<Enemy>().playerObject = playerObject;
        virusClone.GetComponent<Enemy>().gameHandler = this;
        virusClone.GetComponent<Enemy>().scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    public void setGameStarted(bool value) {
        this.gameStarted = value;
    }
    public bool getGameStatus() {
        return this.gameStarted;
    }

    public void setGameOver(){
        this.setGameStarted(false);
        this.menuHandler.gameoverScreen();
    }

    public void takeVirusCount() {
        this.enemyCount--;
    }
}
