using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    //[SerializeField] private GameObject completeImage;  //Image goes here
    private AudioSource audioSource; //Sound that triggers when goal is touched


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audioSource = GetComponent<AudioSource>(); //Sets the audio


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play(); //Plays the audio
            }


        }
        StartCoroutine(ResetLevelAfterDelay(2f));


    }
    private System.Collections.IEnumerator ResetLevelAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Test Level"); // Reload current scene
    }
}
