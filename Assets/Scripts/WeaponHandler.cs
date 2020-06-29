using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private ParticleSystem part;
    
    [SerializeField] private Weapon weapon;
    /*public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 1.0F;*/
    void Start()
    {
        part = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //var main = part.main;
        //main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);
    }

    private void OnParticleCollision(GameObject other) {
        Enemy enemy = other.GetComponent<Enemy>();
        if (other.tag == "Enemy") {
            enemy.takeDamage(weapon.getCurrentWeaponDamage());
        }
    }
}
