using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;
using System.Linq;
public class ScoreManager : MonoBehaviour
{
    //private List<PlayerScore> scoreData = new List<PlayerScore>();
    private Dictionary<System.DateTime, int> scoreData = new Dictionary<System.DateTime, int>();
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

    public void resetLeaderboardData(){
        if (SaveGame.Exists(this.scoreKey)){
            SaveGame.Clear();
        }
    }
    
    public void saveToLeaderboard(){
        /*PlayerScore data = new PlayerScore(this.getScore(), System.DateTime.Today);

        this.scoreData = SaveGame.Load<List<PlayerScore>>(this.scoreKey);
        Debug.Log(data);
        this.scoreData.Add(data);
        SaveGame.Save<List<PlayerScore>>(this.scoreKey, this.scoreData);
        */
        PlayerScore data = new PlayerScore(this.getScore(), System.DateTime.Now);
        if (SaveGame.Exists(this.scoreKey)){
            this.scoreData = SaveGame.Load<Dictionary<System.DateTime, int>>(this.scoreKey);
        }
        this.scoreData.Add(data.getDate(), data.getScore());
        SaveGame.Save<Dictionary<System.DateTime, int>>(this.scoreKey, this.scoreData);
        foreach(var dataList in this.scoreData){
            Debug.Log(dataList.Value + " - " + dataList.Key.ToString("dd/MM/yyyy") + " - " + dataList.Key.ToString("HH:mm"));
        }

    }
    public void addDataToUI(TMP_Text[] texts){
        /*
        int counter = 0;
        if (SaveGame.Exists(this.scoreKey)){
            foreach(PlayerScore data in SaveGame.Load<List<PlayerScore>>(this.scoreKey)){
                texts[counter].text = data.getScore() + " - " + data.getDate().ToString("dd/MM/yyyy") + " - " + data.getDate().ToString("HH:mm");
                texts[counter].gameObject.SetActive(true);
                counter++;
            }
        } else {
            for (int i = 0; i < texts.Length; i++){
                texts[i].gameObject.SetActive(true);
                texts[i].text = "EMPTY";
            }
        }
        */
        int counter = 0;
        if (SaveGame.Exists(this.scoreKey)){
            this.scoreData = SaveGame.Load<Dictionary<System.DateTime, int>>(this.scoreKey);
            foreach(var dataList in this.scoreData){
                /*texts[counter].text = dataList.Value + " - " + dataList.Key.ToString("dd/MM/yyyy") + " - " + dataList.Key.ToString("HH:mm");
                texts[counter].gameObject.SetActive(true);
                counter++;*/
                if (counter < texts.Length){
                    texts[counter].gameObject.SetActive(true);
                    texts[counter].text = dataList.Value + " - " + dataList.Key.ToString("dd/MM/yyyy") + " - " + dataList.Key.ToString("HH:mm");
                    counter++;
                }

            }
            for (int i = 0; i < counter; i++){
                for (int x = 0; x < (counter - 1); x++){
                    string search = texts[x].text;
                    string[] resultString = search.Split('-');
                    int resultScore = int.Parse(resultString[0]);

                    string search2 = texts[x + 1].text;
                    string[] resultString2 = search2.Split('-');
                    int resultScore2 = int.Parse(resultString2[0]);

                    if (resultScore < resultScore2){
                        var temp = texts[x].text;
                        texts[x].text = texts[x + 1].text;
                        texts[x + 1].text = temp;
                    }
                }
            }
        } else {
            /*for (int i = 0; i < texts.Length; i++){
                texts[i].gameObject.SetActive(true);
                texts[i].text = "EMPTY";
            }*/
            texts[4].text = "EMPTY";
        }


    }
}
