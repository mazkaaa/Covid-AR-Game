using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float healthPoint; //5
    [SerializeField] private GameObject player;

    [SerializeField] private Material[] virusColor;
    [SerializeField] private Weapon weapon;

    [SerializeField] private ParticleSystem particle;
    [SerializeField] private List<ParticleCollisionEvent> collisionEvents;

    [SerializeField] private Coin coinAPI;

    private bool chasing = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        coinAPI = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.healthPoint < 0.1f) {
            coinAPI.addCurrentCoin(1);
            this.dead();
        }
    }

    public void attack() {

    }

    public void chase() {
        //rb.AddForce(player.transform.position * 1f);
        gameObject.transform.Translate(player.transform.position * 1f);
    }

    public void stopChasing() {
        //rb.AddForce(player.transform.position * 0f);
        gameObject.transform.Translate(player.transform.position * 0f);
    }

    public void dead() {
        Destroy(gameObject);
    }

    public void takeDamage(float value) {
        this.healthPoint -= value;
    }

    /// <summary>
    /// 0 = idle || 1 = chasing
    /// </summary>
    /// <param name="index"></param>
    public void setVirusMode(int index) {
        switch (index) {
            case 0:
                this.stopChasing();
                break;
            case 1:
                this.chase();
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //this.stopChasing();
            //this.attack();
        }
    }

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Firepoint") {
            this.takeDamage(weapon.getCurrentWeaponDamage());
        }
    }


}
