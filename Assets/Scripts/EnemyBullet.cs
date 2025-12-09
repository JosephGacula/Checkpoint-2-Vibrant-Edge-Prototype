using UnityEngine;


public class EnemyBullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int colorType = 0;

    public float direction = 1f;

      public void SetDirection(float dir)
    {
        direction = dir;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = new Vector2(direction * speed, 0f);


    }

   
}
