using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnArrow : MonoBehaviour
{
    public float timeToAttack;
    public GameObject arrowPrefab;
    float timer;
    public Transform arrowDirection;
    //PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GetComponentInParent<PlayerController>();
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
        
        

    }
}
