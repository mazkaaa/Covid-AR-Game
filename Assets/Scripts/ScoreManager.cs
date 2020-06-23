using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    [SerializeField] private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }
}
