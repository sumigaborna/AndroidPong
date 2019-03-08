using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {

    private float speedOfBall;
    private int PlayerScore = 0;
    private int EnemyScore = 0;

    private Rigidbody2D rb;   
    private Text PlayerScoreText;
    private Text EnemyScoreText;
    private GameObject Player;
    private GameObject Enemy;

    private GameObject BallHitSE;
    private GameObject WallHitSE;
    private GameObject ScoreHitSE;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speedOfBall = 8f; 
        PlayerScoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
        EnemyScoreText = GameObject.Find("EnemyScore").GetComponent<Text>();
        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("Enemy");
        BallHitSE = GameObject.Find("ballHitSE");
        WallHitSE = GameObject.Find("wallHitSE");
        ScoreHitSE = GameObject.Find("scoreHitSE");

        StartCoroutine(HoldBall());

    }

    // Update is called once per frame
    void Update () {
        PlayerScoreText.text = PlayerScore.ToString();
        EnemyScoreText.text = EnemyScore.ToString();
    }

    void MoveBall()
    {

        float tempRand = Random.value; //temporary random value for choosing side (left or right)
        float tempRand2 = Random.value; //temporary random value for choosing top or bottom
        if (tempRand >= 0.5)
        { //leftside  
            if (tempRand2 >= 0.5) //top
            {
                rb.velocity = new Vector2(-1f, 1f) * speedOfBall;
            }
            else if (tempRand2 < 0.5) //bottom
            {
                rb.velocity = new Vector2(-1f, -1f) * speedOfBall;

            }
        }
        else if (tempRand < 0.5)
        { //rightside
            if (tempRand2 >= 0.5) //top
            {
                rb.velocity = new Vector2(1f, 1f) * speedOfBall;

            }
            else if (tempRand2 < 0.5) //bottom
            {
                rb.velocity = new Vector2(1f, -1f)*speedOfBall;

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "top")
        {
            WallHitSE.GetComponent<AudioSource>().Play();
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
            WallHitSE.GetComponent<AudioSource>().Play();
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
            ScoreHitSE.GetComponent<AudioSource>().Play();

            ResetBall();
            EnemyScore++;
        }
        if (collision.transform.name == "right")
        {
            ScoreHitSE.GetComponent<AudioSource>().Play();

            ResetBall();
            PlayerScore++;
        }
        
        if(collision.transform.name == "Player")
        {
            BallHitSE.GetComponent<AudioSource>().Play(); //Plays sound effect on hit
            if (transform.position.y - Player.transform.position.y >= 0) //upper part of paddle
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(1f, 1f) * speedOfBall;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(1f, -1f) * speedOfBall;
                }
            }
            else if (transform.position.y - Player.transform.position.y < 0) //bottom part of paddle
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(1f, 1f) * speedOfBall;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(1f, -1f) * speedOfBall;
                }
            }
        }
        if (collision.transform.name == "Enemy")
        {
            BallHitSE.GetComponent<AudioSource>().Play(); //Plays sound effect on hit
            if (transform.position.y - Enemy.transform.position.y >= 0)
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(-1f, 1f) * speedOfBall;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(-1f, -1f) * speedOfBall;
                }
            }
            else if (transform.position.y - Enemy.transform.position.y < 0)
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(-1f, 1f) * speedOfBall;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(-1f, -1f) * speedOfBall;
                }
            }
        }

    }
    void ResetBall()
    {
        transform.position = new Vector2(0f, 0f);
        MoveBall();
    }

    IEnumerator HoldBall()
    {
        yield return new WaitForSeconds(3);
        transform.position = new Vector2(0, Random.Range(-4f, 4f)); //puts ball at random Y position 
        MoveBall();
    }
    

}
