using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    /// <summary>
    /// 0 = Basic disinfectant with smaller spray area high damage || 1 = Basic disinfectant with wider spray area low damage
    /// </summary>
    [SerializeField] private int currentWeaponType;
    [SerializeField] private float currentWeaponDamage;

    [SerializeField] private GameObject[] weaponObject;
    [SerializeField] private GameObject currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        this.setupWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Setup the current equipped weapon
    /// </summary>
    /// <param name="weapon">0 = Basic disinfectant with smaller spray area high damage || 1 = Basic disinfectant with wider spray area low damage</param>
    public void setupWeapon(int weapon) {
        switch (weapon) {
            case 0:
                this.currentWeaponDamage = 1.2f;
                this.currentWeapon = this.weaponObject[0];
                this.weaponObject[0].SetActive(true);
                this.weaponObject[1].SetActive(false);
                break;
            case 1:
                this.currentWeaponDamage = 0.5f;
                this.currentWeapon = this.weaponObject[1];
                this.weaponObject[0].SetActive(false);
                this.weaponObject[1].SetActive(true);
                break;
        }
    }

    public int getCurrentWeaponType() {
        return this.currentWeaponType;
    }

    public float getCurrentWeaponDamage() {
        return this.currentWeaponDamage;
    }
    public void shootSpray(){
        ParticleSystem sprayBullet = this.currentWeapon.GetComponentInChildren<ParticleSystem>();
        if (!sprayBullet.isPlaying){
            sprayBullet.Play();
        }
    }
}
