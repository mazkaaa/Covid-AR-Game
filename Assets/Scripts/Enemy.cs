using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float healthPoint; //5
    [SerializeField] public GameObject playerObject;

    [SerializeField] private Material[] virusColor;
    [SerializeField] public Weapon weapon;

    [SerializeField] private ParticleSystem particle;
    [SerializeField] private List<ParticleCollisionEvent> collisionEvents;

    [SerializeField] public Coin coinAPI;
    [SerializeField] public Player playerAPI;

    [SerializeField] private float virusSpeed;
    private Vector3 tempPos;

    private bool chasing = false;
    // Start is called before the first frame update
    void Start()
    {
        tempPos = gameObject.transform.position;
        this.virusSpeed = 0.2f;
        //playerObject = GameObject.FindWithTag("Player");
        //weapon = GameObject.FindWithTag("Weapon").GetComponent<Weapon>();
        //coinAPI = GameObject.FindWithTag("GameHandler").GetComponent<Coin>();
        //playerAPI = GameObject.FindWithTag("GameHandler").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.healthPoint < 0.1f) {
            coinAPI.addCurrentCoin(1);
            this.dead();
        }
        if (this.chasing){
            //this.chase();
        } else {
            if (Random.Range(0, 100) > 50){
                gameObject.transform.Translate(new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)) * this.virusSpeed);
            } else {
                gameObject.transform.Translate(playerObject.transform.position * this.virusSpeed);
                Debug.Log(playerObject.transform.position);
            }
            //gameObject.transform.Translate(tempPos * this.virusSpeed);
        }
    }

    public void attack() {

    }

    public void chase() {
        //rb.AddForce(player.transform.position * 1f);
        gameObject.transform.Translate(playerObject.transform.position * this.virusSpeed);
    }

    public void stopChasing() {
        //rb.AddForce(player.transform.position * 0f);
        gameObject.transform.Translate(playerObject.transform.position * this.virusSpeed);
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
                this.chasing = false;
                break;
            case 1:
                this.chase();
                this.chasing = true;
                break;
        }
    }

    public void setVirusHealth(float value){
        this.healthPoint = value;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.setVirusMode(0);
            playerAPI.takeCurrentHealth(1);
            this.dead();
        }
        if (other.tag == "PlayerDetection"){
            this.setVirusMode(1);
        }
    }

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Firepoint") {
            this.takeDamage(weapon.getCurrentWeaponDamage());
        }
    }




}
