using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float lifetime;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float Speed;
    private bool scoreadded = false;
    private void Update()
    {
        // moves obstacle down 
        transform.Translate(Vector2.down * (Speed * Time.deltaTime));
        //despawns obstacles after set time
        lifetime += Time.deltaTime;
        if (lifetime >= 8)
        {
            Destroy(gameObject);
        }

        if (obstacle.transform.position.y <= -2)
        {
            if (!scoreadded)
            {
                Player.score++;
                scoreadded = true;
            }
        }
    }

    // damages player on collision 
    private void OnTriggerEnter2D(Collider2D other)
 {
     if (other.CompareTag("Player"))
     {
         other.GetComponent<Player>().health -= 1;
         Destroy(gameObject);
     }
 }
}
