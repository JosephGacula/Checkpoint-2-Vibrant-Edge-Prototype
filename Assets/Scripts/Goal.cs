using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Goal : MonoBehaviour
{
    //[SerializeField] private GameObject completeImage;  //Image goes here
    private AudioSource audioSource; //Sound that triggers when goal is touched
    public GameObject rank;
    public TextMeshProUGUI rankText;
    public char rankLetter;
    ScoreCounter scoreCounter;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        audioSource = GetComponent<AudioSource>(); //Sets the audio
        if (rank != null)
            rank.SetActive(false);  // Hide rankText at start

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject Score = GameObject.Find("Score");
            if (Score != null)
            {
                scoreCounter = Score.GetComponent<ScoreCounter>();
            }

            if (scoreCounter.score >= 80)
            {
                rankLetter = 'S';
            }
            else if (scoreCounter.score >= 50)
            {
                rankLetter = 'A';
            }
            else if (scoreCounter.score >= 30)
            {
                rankLetter = 'B';
            }
            else if (scoreCounter.score <= 30)
            {
                rankLetter = 'C';
            }


            if (audioSource != null)
            {
                audioSource.Play(); //Plays the audio
            }
            if (rank != null)
            {

                rank.SetActive(true);  // show text
                rankText.text = string.Format("Rank: {0}", rankLetter);
            }
            StartCoroutine(ResetLevelAfterDelay(3f));
        }
      

        
    }
    private System.Collections.IEnumerator ResetLevelAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Test Level"); // Reload current scene
    }
}
