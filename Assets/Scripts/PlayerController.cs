using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    
    public float speed = 20.0f;
    public Vector3 forward;
    Vector3 right;
    public float mapRange = 245;
    private AudioSource playerAudio;
    public AudioClip hitSound;
    //private Rigidbody playerRb;
    public float obstacleBounce = 5.0f;
    public int maxLives = 3;
    public int currentLives = 3;
    [SerializeField] int damage = 1;
    [SerializeField] TextMeshProUGUI livesText;
    private Animator playerAnim;
    public float specialAtkCooldown = 0;
    public GameObject specialAtkPrefab;
    public Transform specialAtkDirection;
    public float specialSpeed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        
        //sets 'forward' & right to camera view
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;

    }

    // Update is called once per frame
    void Update()
    {
       livesText.SetText("Lives: " + currentLives);
       if (Input.anyKey) //any input invokes Move method
       {
            Move();
       }
       //prevents player from going out of bounds
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
       if (Input.GetKeyDown(KeyCode.Space) && specialAtkCooldown <=0)
       {
        SpecialAtk();
       }
       if (specialAtkCooldown >0)
       {
        specialAtkCooldown -= Time.deltaTime;
       }
       if(currentLives == 0)
        {
        Debug.Log("You have died");
        Destroy(gameObject);
        }
        
    }
    void Move() //moves player on isometric plane
    {
        new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 heading = Vector3.Normalize(upMovement + rightMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        playerAnim.Play("Run", 3, 0f);
        
    }
    void SpecialAtk()
    {
        Instantiate(specialAtkPrefab, specialAtkDirection.position, specialAtkDirection.rotation);
        specialAtkPrefab.transform.Translate(Vector3.forward * Time.deltaTime * specialSpeed);
        specialAtkCooldown = 10;
    }
    private void OnCollisionEnter(Collision collision) //play sound if player hit by enemy
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Hit!");
            playerAudio.PlayOneShot(hitSound, 0.4f);
            currentLives -= damage;
                       
            }
            

        //if(collision.gameObject.CompareTag("Obstacle")) {Vector3 awayFromObstacle =  transform.position - collision.gameObject.transform.position;playerRb.AddForce(awayFromObstacle * obstacleBounce, ForceMode.Impulse);}
        }
}

