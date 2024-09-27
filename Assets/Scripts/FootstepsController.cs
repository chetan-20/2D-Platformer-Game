using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    private PlayerController playerController;
    public AudioSource footstepsSound;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
           
                            
                footstepsSound.enabled = true;
                
        }
        else if(playerController.lives<=0)
        {
            footstepsSound.enabled = false;
            
        }
        else
        {
            footstepsSound.enabled = false;
        }
    }
}
