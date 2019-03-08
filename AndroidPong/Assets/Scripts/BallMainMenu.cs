using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMainMenu : MonoBehaviour {

    private Rigidbody2D rb;
    private float speedOfBall;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        speedOfBall = 5f;
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speedOfBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "top")
        {
            if (rb.velocity.x > 0) //right
            {
                rb.velocity = new Vector2(1f, -1f) * speedOfBall;
            }
            else if (rb.velocity.x < 0) //left
            {
                rb.velocity = new Vector2(-1f, -1f) * speedOfBall;

            }
        }
        if (collision.transform.name == "bottom")
        {
            if (rb.velocity.x > 0) //right
            {
                rb.velocity = new Vector2(1f, 1f) * speedOfBall;
            }
            else if (rb.velocity.x < 0) //left
            {
                rb.velocity = new Vector2(-1f, 1f) * speedOfBall;

            }
        }
        if (collision.transform.name == "left")
        {
            if (rb.velocity.y > 0) //top
            {
                rb.velocity = new Vector2(1f, 1f) * speedOfBall;
            }
            else if (rb.velocity.y < 0) //bottom
            {
                rb.velocity = new Vector2(1f, -1f) * speedOfBall;

            }
        }
        if (collision.transform.name == "right")
        {
            if (rb.velocity.y > 0) //top
            {
                rb.velocity = new Vector2(-1f, 1f) * speedOfBall;
            }
            else if (rb.velocity.y < 0) //bottom
            {
                rb.velocity = new Vector2(-1f, -1f) * speedOfBall;

            }
        }
    }
}
