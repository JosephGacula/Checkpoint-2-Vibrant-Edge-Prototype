using UnityEngine;
using UnityEngine.Audio;

public class TerrainBulletCollide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            
            EnemyBullet bulletToCheck = collision.GetComponent<EnemyBullet>();
            if (bulletToCheck != null)
            {

               

                Destroy(collision.gameObject);
            }

            



        }
        if (collision.CompareTag("Bullet"))
        {
            Bullet bulletToCheck2 = collision.GetComponent<Bullet>();
            if (bulletToCheck2 != null)
            {



                Destroy(collision.gameObject);
            }

        }
    }
}
