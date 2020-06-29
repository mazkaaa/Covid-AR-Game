using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadoutHandler : MonoBehaviour
{
    public ItemList[] itemObjectLists;
    public LoadoutItems[] loadoutDataItems;
    public TMP_Text coinvalText;
    public Coin coinAPI;
    // Start is called before the first frame update
    void Start()
    {
        //this.coinAPI.addTotalSavedCoin(999999);
        this.getAllDataToInterface();
    }

    // Update is called once per frame
    void Update()
    {
        this.coinvalText.text = "coin: " + this.coinAPI.getTotalSavedCoin().ToString();
    }

    private void getAllDataToInterface(){
        for (int i = 0; i < this.loadoutDataItems.Length; i++){
            this.itemObjectLists[i].gameObject.SetActive(true);
            this.itemObjectLists[i].weaponName.text = this.loadoutDataItems[i].weaponName;
            if (this.loadoutDataItems[i].equipped){
                this.itemObjectLists[i].equipStatus.text = "Equipped";
            } else {
                if (this.loadoutDataItems[i].owned){
                    this.itemObjectLists[i].equipStatus.text = "Use item";
                } else {
                    this.itemObjectLists[i].equipStatus.text = this.loadoutDataItems[i].price.ToString();
                }
            }
        }
    }

    public void useItem(int index){
        if (this.loadoutDataItems[index].owned){
            for (int i = 0; i < this.loadoutDataItems.Length; i++){
                if (this.loadoutDataItems[i].owned){
                    this.itemObjectLists[i].equipStatus.text = "Use item";
                    this.loadoutDataItems[i].equipped = false;
                } else {
                    this.itemObjectLists[i].equipStatus.text = this.loadoutDataItems[i].price.ToString();
                }
            }
            this.itemObjectLists[index].equipStatus.text = "Equipped";
            this.loadoutDataItems[index].equipped = true;
        } else {
            if (this.coinAPI.getTotalSavedCoin() < this.loadoutDataItems[index].price){
                // not enough coin
            } else {
                this.coinAPI.takeTotalSavedCoin(this.loadoutDataItems[index].price);
                this.loadoutDataItems[index].owned = true;
                this.itemObjectLists[index].equipStatus.text = "Use Item";
            }
        }
    /*
        for (int i = 0; i < this.loadoutDataItems.Length; i++){
            if (this.loadoutDataItems[i].owned){
                this.itemObjectLists[i].equipStatus.text = "Use item";
                this.loadoutDataItems[i].equipped = false;
            } else {
                this.itemObjectLists[i].equipStatus.text = this.loadoutDataItems[i].price.ToString();
            }
        }
        this.itemObjectLists[index].equipStatus.text = "Equipped";
        this.loadoutDataItems[index].equipped = true;*/
    }

    private void updateDataUi(){
        for (int i = 0; i < this.loadoutDataItems.Length; i++){

        }
    }
}
