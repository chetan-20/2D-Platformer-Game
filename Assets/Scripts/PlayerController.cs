using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb; 
    public float jump = 3f;
    public float speed = 1f;
    private bool iscrouch=false;
    private bool isGrounded = true;
    public ScoreController scoreController;
    private bool canjump = false;
    internal int lives = 3;
    public GameOver gameover;
    private FootstepsController footstepsController;
    [SerializeField] GameObject heart1, heart2, heart3;
    [SerializeField] AudioSource DeathSound;
    [SerializeField] AudioSource JumpSound;
    [SerializeField] AudioSource KeyPickUp;
    [SerializeField] public AudioSource LiveLostSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();         
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsJumping", false);
       
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
      
    }

    private void UpdateLivesUI()
    {
        switch(lives)
        {
            case 2:
                heart3.SetActive(false);
               
                break;
            case 1:
                heart2.SetActive(false);
               
                break;
            case 0: heart1.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool ctrlpressed = Input.GetKeyDown(KeyCode.LeftControl);
        float horispeed = Input.GetAxisRaw("Horizontal");
        Flipx(horispeed);
        Move(horispeed);
        Jumpy();                   
        Crouchy(ctrlpressed);
        UpdateLivesUI();                         
    }

    void Move(float horispeed)
    {
        Vector2 newposition = transform.position;
        newposition.x += horispeed*speed*Time.deltaTime;
        transform.position = newposition;
    }
    void Flipx(float horispeed)
    {
        if (horispeed < 0)
        {
            spriteRenderer.flipX = true;

        }
        if (horispeed > 0)
        {
            spriteRenderer.flipX = false;

        }
        animator.SetFloat("Speed", horispeed);
    }
    void Jumpy()
    {
        
        if ( Input.GetKeyDown(KeyCode.Space)  && isGrounded == true && canjump){
            JumpSound.Play();
            animator.SetBool("IsJumping", true);           
            rb.velocity = new Vector2(rb.velocity.x, jump);
            
            isGrounded = false;
            canjump = false;
        }
        else if(!isGrounded)
        {
           
            animator.SetBool("IsJumping", false);
            Standing();
        }
    }

    void Crouchy(bool ctrlpress)
    {
        if (ctrlpress && !iscrouch && isGrounded)
        {
            iscrouch = true;           
            animator.SetBool("IsCrouching", true);                                        
        }
        if (iscrouch && !ctrlpress )
        {           
            Standing();
        }
        
             
    }

    void Standing()
    {
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsJumping", false);
        iscrouch=false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canjump = true;
           
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void PickUpKey()
    { 
        KeyPickUp.Play();
        scoreController.UpdateScore(10);
       
    }

    public void KillPlayer()
    {
        if (lives <= 0)
        {
            animator.SetBool("IsDead", true);
            
            DeathSound.Play();
        }
    }
    
    //will be called once animation Ends
    public void OnDeathAnimationEnd()
    {
        if (animator.GetBool("IsDead") == true)
        {
           
           
           gameover.OnGameOver(); 
        }
    }
}
