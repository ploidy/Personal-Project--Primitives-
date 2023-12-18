using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    public GameObject player;
    public float mapRange = 245f;
    //public Transform target;
    public float rotationSpeed = 60.0f;
    //[SerializeField] int maxHP;
    //private int currentHP;
    //[SerializeField] int damage = 1;
    //public int scoreValue;
    private GameManager gameManager;
    [SerializeField] int enemyXp;



    
   
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

     }

    // Update is called once per frame
    void Update()
    {
        //Enemies find player direction and move towards player ** Note - fix enemies overshooting player location
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        transform.position += lookDirection * speed * Time.deltaTime;
        //enemyRb.AddForce(lookDirection * speed);

       // stops Enemies moving out of bounds
       if (transform.position.x < -mapRange)
       {
        transform.position = new Vector3(-mapRange, transform.position.y, transform.position.z);
       }
       if (transform.position.x > mapRange)
       {
        transform.position = new Vector3(mapRange, transform.position.y, transform.position.z);
       }
       if (transform.position.z < -mapRange)
       {
        transform.position = new Vector3(transform.position.x, transform.position.y, -mapRange);
       }
       if (transform.position.z > mapRange)
       {
        transform.position = new Vector3(transform.position.x, transform.position.y, mapRange);
       }

    
    }
    IEnumerator OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        speed = speed * 0.4f;
        yield return new WaitForSeconds (2.0f);
        speed = speed * 2.5f;
       
        //transform.position = new Vector3 (transform.position.x -5, transform.position.y, transform.position.z -5).normalized;
        //player.GetComponent<Level>().AddXp(enemyXp);
        }
    }
}
