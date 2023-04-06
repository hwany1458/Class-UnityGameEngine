using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundSound2D : MonoBehaviour
{
    AudioSource ballSound;

    // Start is called before the first frame update
    void Start()
    {
        ballSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballSound.Play();
    }
}
