using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrow : MonoBehaviour
{
    public float speed;
    public float Lifespan;
    //private Rigidbody arrowRB;
    public AudioClip arrowSound;
    private AudioSource arrowAudio;
    // Start is called before the first frame update
    
    void Start()
    {
        //arrowRB = GetComponent<Rigidbody>();
        arrowAudio = GetComponent<AudioSource>();
    }
    


    // Update is called once per frame
    void Update()
    {
        //fire arrow in 'forward' direction and destroy after Lifespan seconds
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
                
        //play arrow audio on fire
        arrowAudio.PlayOneShot(arrowSound, 0.6f);

        //destory arrow after Lifespan
        Destroy(gameObject, Lifespan);
    }
}
