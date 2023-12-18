using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCollisions : MonoBehaviour
{
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        lifespan = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy (gameObject,lifespan);
    }


 
}
