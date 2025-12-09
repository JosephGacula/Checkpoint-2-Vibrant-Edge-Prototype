using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    int health;
    
    void Start()
    {
        health = 30;
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

                    health -= 10;

                Destroy(collision.gameObject);
            }

            if (health <= 0)
            {
                StartCoroutine(ResetLevelAfterDelay(2f));
            }

        }
    }

    private System.Collections.IEnumerator ResetLevelAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Test Level"); // Reload current scene
    }
}
