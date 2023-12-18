using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wpnArrow : MonoBehaviour
{
    public float timeToAttack;
    public GameObject arrowPrefab;
    float timer;
    public Transform arrowDirection;
    public AudioClip arrowSound;
    private AudioSource arrowAudio;
    public GameObject player;
    [SerializeField] GameObject button;
    [SerializeField] UpgradeMenuManager upgradeMenu;
    
    //PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GetComponentInParent<PlayerController>();
        arrowAudio = GetComponent<AudioSource>();
        timeToAttack = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //sets timer for firing arrows
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnArrow();
    }
    void SpawnArrow() //spawns arrow 
    {
        Instantiate(arrowPrefab, arrowDirection.position, arrowDirection.rotation);
        arrowAudio.PlayOneShot(arrowSound, 0.6f);
    }

    public void UpgradeArrow()
    {
        if (timeToAttack <= 1.0f)
        {
            button.SetActive(false);
        }
        else 
        {
        timeToAttack -= 0.2f;
        upgradeMenu.CloseMenu();
        
        }
    }
}
