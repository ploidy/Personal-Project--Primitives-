using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 20.0f;
    public Vector3 forward;
    Vector3 right;
    public float mapRange = 245;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.anyKey)
       {
            Move();
       }
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
    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 heading = Vector3.Normalize(upMovement + rightMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
