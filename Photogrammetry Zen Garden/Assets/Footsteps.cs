using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    float dirX;
    [SerializeField]
    float moveSpeed = 5f;
    Rigidbody rb;
    AudioSource audioSrc;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody> ();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        if (rb.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
        
            audioSrc.Stop();

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);   
    }
}
