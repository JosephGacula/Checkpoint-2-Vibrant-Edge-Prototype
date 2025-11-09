using System; //For random number generation
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;


public class Enemy : MonoBehaviour
{
    int health;
    int type; //0 is Red, 1 is Green, 2 is Blue
    ScoreCounter scoreCounter;

    void Start()
    {
        GameObject Score = GameObject.Find("Score");
        if (Score != null)
        {
            scoreCounter = Score.GetComponent<ScoreCounter>();
        }



        health = 20;

        System.Random rand = new System.Random();
        type = rand.Next(0, 3); //Set enemy type


        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            switch (type)
            {
                case 0:
                    sr.color = Color.red;
                    break;
                case 1:
                    sr.color = Color.green;
                    break;
                case 2:
                    sr.color = Color.blue;
                    break;
            }

        }
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet bulletToCheck = collision.GetComponent<Bullet>();
            if (bulletToCheck != null)
            {

                if (bulletToCheck.colorType == type)
                {
                    health -= 5;
                }


                Destroy(collision.gameObject);
            }

        }

        if (collision.CompareTag("Slash"))
        {
            Slash slashToCheck = collision.GetComponent<Slash>();
            if (slashToCheck != null)
            {

                if ((slashToCheck.slashType == type) && (health <= 0))
                {
                    scoreCounter.score += 10;
                    Destroy(gameObject);
                }

                Destroy(collision.gameObject);
            }

        }
    }
}

