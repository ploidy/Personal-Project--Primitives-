using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        gameManager.UpdateScore(+1);
        }
        if (other.gameObject.tag == "SpecialAtk")
        {
        Destroy(gameObject);
        gameManager.UpdateScore(+1);
        }
    }
}
