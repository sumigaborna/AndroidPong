using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private GameObject Ball;
    private float tempRand;

	// Use this for initialization
	void Start () {
        Ball = GameObject.Find("Ball");
        tempRand = Random.Range(0.65f, 0.8f); //random number for AI's reaction speed on start of the game
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, Ball.transform.position.y*tempRand, 0);
        //Debug.Log(tempRand);
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Ball.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            tempRand = Random.Range(0.65f, 0.8f); //random number for AI's reaction speed after every hit
        }
        else
        {
            tempRand = 1;
        }
    }
}
