using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        videoPlayer.loopPointReached += OnMovieFinished;
    }

    void OnMovieFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("Test Level");
    }
}
