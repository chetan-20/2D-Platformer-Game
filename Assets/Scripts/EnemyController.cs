using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private bool collisionoccured=false;//needed so that collision statement is ran only once
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collisionoccured && collision.gameObject.CompareTag("Player"))
        {
            collisionoccured = true;
            playerController.lives--;
            SoundController.Instance.PlaySound(Sounds.HealthLostSound);
            playerController.KillPlayer();
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionoccured=false;//reset when collision is finished
    }
}
