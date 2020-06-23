using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private int coinValue;

    private string coinKey = "coinkey";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    /// <summary>
    /// Get total saved coin from player prefs
    /// </summary>
    /// <returns></returns>
    public int getTotalSavedCoin(){
        return PlayerPrefs.GetInt(coinKey);
    }

    public void setTotalSavedCoin(int value){
        PlayerPrefs.SetInt(coinKey, value);
        PlayerPrefs.Save();
    }
    public void addTotalSavedCoin(int value) {
        PlayerPrefs.SetInt(coinKey, (PlayerPrefs.GetInt(coinKey) + value));
        PlayerPrefs.Save();
    }
    public void takeTotalSavedCoin(int value){
        PlayerPrefs.SetInt(coinKey, (PlayerPrefs.GetInt(coinKey) - value));
        PlayerPrefs.Save();
    }


    public int getCurrentCoin(){
        return coinValue;
    }
    public void setCurrentCoin(int value){
        coinValue = value;
    }
    public void addCurrentCoin(int value){
        coinValue = coinValue + value;
    }
}
