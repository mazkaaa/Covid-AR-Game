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
    [SerializeField] public ScoreManager scoreManager;

    [SerializeField] private float virusSpeed;
    [SerializeField] public GameHandler gameHandler;

    [SerializeField] public Rigidbody rb;
    private Vector3 tempPos;

    private bool chasing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
        tempPos = gameObject.transform.position;
        this.virusSpeed = 0.5f;
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
            scoreManager.addScore(Random.Range(2, 18));
            this.dead();
        }
        if (this.chasing){
            this.chase();
        } else {
            this.idling();
        }
    }

    public void attack() {

    }

    public void chase() {
        //gameObject.transform.Translate(new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z) * this.virusSpeed);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerObject.transform.position, virusSpeed * Time.deltaTime);
    }
    public void idling(){
        if (Random.Range(0, 100) > 60){
            gameObject.transform.Translate(new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)) * this.virusSpeed);
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)), virusSpeed * Time.deltaTime);
        }
    }

    public void stopChasing() {
        //rb.AddForce(player.transform.position * 0f);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerObject.transform.position, 0f);
    }

    public void dead() {
        //rb.WakeUp();
        //rb.isKinematic = false;
        this.setVirusMode(0);
        playerAPI.takeCurrentHealth(1);
        gameHandler.takeVirusCount();
        Destroy(gameObject);
        Debug.Log("Virus touching player");
        gameHandler.takeVirusCount();
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
            this.dead();
        }
        if (other.tag == "PlayerDetection"){
            this.setVirusMode(1);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            this.dead();
        }
        if (collision.collider.tag == "PlayerDetection") {
            this.setVirusMode(1);
        }
    }
    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Firepoint") {
            this.takeDamage(weapon.getCurrentWeaponDamage());
        }
    }




}
