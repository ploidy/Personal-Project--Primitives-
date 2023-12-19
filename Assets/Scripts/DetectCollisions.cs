using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    //public int scoreValue;
    public GameObject player;
    public GameObject enemy;
    public int enemyXp;
    public int maxHp;
    public int damage;
    public ParticleSystem deathParticle;
    public GameObject smokeObject;
    GameObject smokeObjectTemp;
    public float smokeTime = 0.5f;

    
    // Start is called before the first frame update

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        damage = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(maxHp <= 0)
        {
        Destroy(gameObject);
        smokeObjectTemp = Instantiate(smokeObject);
        Instantiate(smokeObjectTemp, transform.position,transform.rotation);
        Destroy(smokeObjectTemp, smokeTime);
        player.GetComponent<Level>().AddXp(enemyXp);
        }
    }
    void OnTriggerEnter(Collider other) { //detroy arrow and enemy on collision
        
        if (other.gameObject.tag == "Arrow")
        {
        //Destroy(gameObject);
        maxHp -= damage;
        deathParticle.Play();
        Destroy(other.gameObject);

        //player.GetComponent<Level>().AddXp(enemyXp);
        //gameManager.UpdateScore(+scoreValue);
        }
        if (other.gameObject.tag == "SpecialAtk")
        {
        //Destroy(gameObject);
        maxHp -= damage * 2;
        deathParticle.Play();
        //player.GetComponent<Level>().AddXp(enemyXp);
        //gameManager.UpdateScore(+scoreValue);
        }
        if (other.gameObject.tag == "Player")
        {
        maxHp -= damage;
        }
    }
}
