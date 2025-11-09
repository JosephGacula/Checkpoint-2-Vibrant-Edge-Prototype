using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
   
}
