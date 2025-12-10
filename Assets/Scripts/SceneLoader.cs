using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
        
    public void quitGame()
    {
        Application.Quit();
    }
}
