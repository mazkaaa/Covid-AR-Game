﻿using System.Collections;
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
    [SerializeField] private Enemy enemyAPI;

    [SerializeField] private bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameStarted) {
            int chance = Random.Range(0, 100);
            if (chance > 70) {
                setRandomSpawnEnemy();
            }
        }
    }

    /// <summary>
    /// Randomly spawn enemy enemySpawner gameobject. dont use this function without delaying the function.
    /// </summary>
    public void setRandomSpawnEnemy() {
        Instantiate(enemyObject, enemySpawner[Random.Range(0, enemySpawner.Length)].transform);
    }
}