using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using TMPro;

public class LeaderboardHandler : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreAPI;
    [SerializeField] private TMP_Text[] highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDataToUI(){
        for (int i = 0; i < this.highscoreText.Length; i++){
            //this.highscoreText[i].text = "";
            this.highscoreText[i].gameObject.SetActive(false);
        }
        this.scoreAPI.addDataToUI(highscoreText);
    }   
    public void resetLeaderboard(){
        this.scoreAPI.resetLeaderboardData();
        this.addDataToUI();
    }
}