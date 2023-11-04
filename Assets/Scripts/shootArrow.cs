using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrow : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public float Lifespan;
    private Rigidbody arrowRB;
    // Start is called before the first frame update
    void Awake() 
    {
        arrowRB = GetComponent<Rigidbody>();
    }
    
    void Start()
    {

    }
    


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Destroy(gameObject, Lifespan);

    }
}
