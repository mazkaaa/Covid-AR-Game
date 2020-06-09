using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private float playerHealth;
    [SerializeField] private Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = this.getCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = this.getCurrentHealth();
    }

    public float getCurrentHealth(){
        return this.playerHealth;
    }
    public void setCurrentHealth(float value){
        this.playerHealth = value;
    }
    public void takeCurrentHealth(float value){
        this.playerHealth -= value;
    }
}
