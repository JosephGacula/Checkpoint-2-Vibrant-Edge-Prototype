using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public TextMeshProUGUI scoreCountText;
    public int score;
    
    void Start()
    {
        score = 0;
        
    }

   
    void Update()
    {
        scoreCountText.text = string.Format("Score: {0}", score);
    }
}
