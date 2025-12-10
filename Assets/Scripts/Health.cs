using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class Health : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitSFX;
    int health;

    
    public TextMeshProUGUI healthText;

    void Start()
    {
        health = 50;
       
        healthText.text = string.Format("Health: {0}", health);
    }

    // Update is called once per frame
    void Update()
    {   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            audioSource.PlayOneShot(hitSFX);
            EnemyBullet bulletToCheck = collision.GetComponent<EnemyBullet>();
            if (bulletToCheck != null)
            {

                    health -= 10;
                healthText.text = string.Format("Health: {0}", health);

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
