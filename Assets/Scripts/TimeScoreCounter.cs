using UnityEngine;
using TMPro;

public class PushTest : MonoBehaviour
{
    public TextMeshProUGUI timeCountText;
    
    public float time;
   


    void Start()
    {
        time = 0f;
        timeCountText.text = "Time: " + time;
        

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);


       
        timeCountText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        


    }
}
