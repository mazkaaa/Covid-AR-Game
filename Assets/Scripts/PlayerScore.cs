using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScore{
    private int score;
    private System.DateTime date;
    public PlayerScore(int scoreValue, System.DateTime dateData){
        this.score = scoreValue;
        this.date = dateData;
    }

    public int getScore(){
        return this.score;
    }
    public System.DateTime getDate(){
        return this.date;
    }
}
