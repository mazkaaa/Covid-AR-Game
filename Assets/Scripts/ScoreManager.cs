using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;
public class ScoreManager : MonoBehaviour
{
    private List<PlayerScore> scoreData = new List<PlayerScore>();
    [SerializeField] private int score;
    private string scoreKey = "scoreKey";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getscoreKey(){
        return this.scoreKey;
    }

    public void setScore(int value){
        this.score = value;
    }
    public void addScore(int value){
        this.score += value;
    }
    public void takeScore(int value){
        this.score -= value;
    }
    public int getScore(){
        return this.score;
    }
    
    public void saveToLeaderboard(){
        PlayerScore data = new PlayerScore();

        data.score = this.getScore();
        data.date = System.DateTime.Today;

        this.scoreData = SaveGame.Load<List<PlayerScore>>(this.scoreKey);
        this.scoreData.Add(data);
        SaveGame.Save<List<PlayerScore>>(this.scoreKey, this.scoreData);


        
    }
    public void addDataToUI(TMP_Text[] texts){
        int counter = 0;
        if (SaveGame.Exists(this.scoreKey)){
            foreach(PlayerScore data in SaveGame.Load<List<PlayerScore>>(this.scoreKey)){
                texts[counter].text = data.score + " - " + data.date.ToString("dd/MM/yyyy") + " - " + data.date.ToString("HH:mm");
                texts[counter].gameObject.SetActive(true);
                counter++;
            }
        } else {
            for (int i = 0; i < texts.Length; i++){
                texts[i].gameObject.SetActive(true);
                texts[i].text = "EMPTY";
            }
        }
    }
}
