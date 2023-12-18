using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;


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
    public int currentLives;
    int damage = 1;
    [SerializeField] TextMeshProUGUI livesText;
    private Animator playerAnim;
    public float specialAtkCooldown;
    private float cooldownValue;
    public GameObject specialAtkPrefab;
    public Transform specialAtkDirection;
    [SerializeField] GameObject livesButton;
    [SerializeField] GameObject specialButton;
    [SerializeField] UpgradeMenuManager upgradeMenu;


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

        currentLives = 3;
        specialAtkCooldown = 0;
        cooldownValue = 10;
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

        specialAtkCooldown = cooldownValue;
    }
    private void OnCollisionEnter(Collision collision) //play sound if player hit by enemy
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Hit!");
            playerAudio.PlayOneShot(hitSound, 0.4f);
            currentLives -= damage;
                       
        }
 
    }
    public void ReplenishLives()
    {
        if (currentLives == 3)
        {
        livesButton.SetActive(false);
        }
        else 
        {
        currentLives += 1;
        upgradeMenu.CloseMenu();
        }
    }
    public void UpgradeSpecialAtk()
    {
        if (cooldownValue <= 5.0f)
        {
        specialButton.SetActive(false);
        }
        else 
        {
        cooldownValue -=  1.0f;
        upgradeMenu.CloseMenu();
        
        }
    }
}

