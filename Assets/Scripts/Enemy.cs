using System; //For random number generation
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;


public class Enemy : MonoBehaviour
{
    int health;
    public int type; //0 is Red, 1 is Green, 2 is Blue
    public Animator animator;
    ScoreCounter scoreCounter;
    public AudioSource audioSource;
    public AudioClip damageSFX;


    void Start()
    {
        GameObject Score = GameObject.Find("Score");
        if (Score != null)
        {
            scoreCounter = Score.GetComponent<ScoreCounter>();
        }



        health = 30;

        System.Random rand = new System.Random();
        type = rand.Next(0, 3); //Set enemy type


        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            switch (type)
            {
                case 0:
                    sr.color = Color.red;
                    animator.SetInteger("type", 0);
                    break;
                case 1:
                    sr.color = Color.green;
                    animator.SetInteger("type", 2);
                    break;
                case 2:
                    sr.color = Color.blue;
                    animator.SetInteger("type", 3);
                    break;
            }

        }
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(damageSFX);
        if (collision.CompareTag("Bullet"))
        {
            Bullet bulletToCheck = collision.GetComponent<Bullet>();
            if (bulletToCheck != null)
            {

                if (bulletToCheck.colorType == type)
                {
                    
                    health -= 10;
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

