/*
 * Josh McGrew
 * Assignment 4: Prototype 3
 * player controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public bool isOnGround = true;
    public ForceMode forceMode;
    public bool gameOver = false;
    public float gravityModifier;

    //animation (part 2 work)
    public Animator playerAnimator;
    //explosion particles and dirt particles
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    //audio
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //set reference to the rigidbody component
        rb = GetComponent<Rigidbody>();
        forceMode = ForceMode.Impulse;
        //animator reference
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);

        //set ref to audio source
        playerAudio = GetComponent<AudioSource>();

        //modify gravity
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
            //trigger jump animation
            playerAnimator.SetTrigger("Jump_trig");
            //stop dirt particles
            dirtParticle.Stop();

            //play jump sound
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //start dirt again
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over.");
            gameOver = true;

            //play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //play explosion particles and stop dirt particles
            explosionParticle.Play();
            dirtParticle.Stop();

            //play sound
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
