using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ballcontroller : MonoBehaviour
{
        private Rigidbody2D rb;
        private Vector2 startingVelocity = new Vector2(5f, 5f);

    public GameManager gameManager;

    public void ResetBall()
    {
            transform.position = Vector3.zero;

            if (rb == null) rb = GetComponent<Rigidbody2D>();
            rb.velocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {


      if (collision.gameObject.CompareTag("Wall"))
      {
        Vector2 newVelocity = rb.velocity;
        newVelocity.y = -newVelocity.y;
        rb.velocity = newVelocity;
      }

      if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
      {
        rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
      }

      if (collision.gameObject.CompareTag("WallEnemy"))
      {
        gameManager.ScorePlayer();
        ResetBall();
       }
      else if (collision.gameObject.CompareTag("WallPlayer"))
      {
       gameManager.ScoreEnemy();
       ResetBall();
      }
    }
}
