using Unity.VisualScripting;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public float fireRate = 2f;
    public float nextFire = 0f;

    private Enemy mainEnemyScript;
    public AudioSource audioSource;
    public AudioClip shootSFX;
    private Transform playerTransform; //for detecting the player
    public float firingRange = 10f;

    //possibly bring in player so that they can turn around?

    void Start()
    {
        mainEnemyScript = GetComponent<Enemy>(); //get the enemy type immediately
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        
    }


    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        // 2. Check if the current time has passed the "nextFireTime"
        if ((distanceToPlayer <= firingRange) && (Time.time >= nextFire)) //Research Time
        {
            audioSource.PlayOneShot(shootSFX);
            shoot();
            // 3. Set the next time to fire
            nextFire = Time.time + fireRate;
        }

    }

    void shoot()
    {
         GameObject bulletToDestroy = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
         SpriteRenderer sr = bulletToDestroy.GetComponent<SpriteRenderer>();
         EnemyBullet bulletScript = bulletToDestroy.GetComponent<EnemyBullet>();

         float dir = playerTransform.position.x < transform.position.x ? -1f : 1f;
        bulletScript.SetDirection(dir);
        
         if (bulletScript != null)
        {
            
            bulletScript.colorType = mainEnemyScript.type;
            if (sr != null)
        {
            switch (mainEnemyScript.type)
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



        
        
        Destroy(bulletToDestroy, 2f); 


    }

}
}