using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text coinValueText;
    [SerializeField] private TMP_Text coinSavedText;

    [SerializeField] private Coin coinAPI;

    [SerializeField] private GameObject[] enemySpawner;
    [SerializeField] private GameObject enemyObject;

    [SerializeField] private Player player;

    [SerializeField] private bool gameStarted;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private int enemyWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameStarted) {
            int chance = Random.Range(0, 100);
            if (chance > 95 && this.enemyWave < this.enemySpawner.Length) {
                setRandomSpawnEnemy();
                this.enemyWave++;
            }

            if (player.getCurrentHealth() < 0.1f){
                this.setGameOver();
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
        virusClone.GetComponent<Enemy>().playerObject = this.playerObject;
    }

    public void setGameStarted(bool value) {
        this.gameStarted = value;
    }
    public bool getGameStatus() {
        return this.gameStarted;
    }

    public void setGameOver(){

    }
}
