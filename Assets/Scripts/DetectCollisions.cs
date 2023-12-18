using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    //public int scoreValue;
    public GameObject player;
    public int enemyXp;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) { //detroy arrow and enemy on collision
        
        if (other.gameObject.tag == "Arrow")
        {
        Destroy(gameObject);
        Destroy(other.gameObject);
        player.GetComponent<Level>().AddXp(enemyXp);
        //gameManager.UpdateScore(+scoreValue);
        }
        if (other.gameObject.tag == "SpecialAtk")
        {
        Destroy(gameObject);
        player.GetComponent<Level>().AddXp(enemyXp);
        //gameManager.UpdateScore(+scoreValue);
        }
    }
}
