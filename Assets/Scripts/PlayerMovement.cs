using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    float sprint = 1f;


    // Update is called once per frames
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Sprint"))
        {
            sprint = 10f;
        }
        else
        {
             sprint = 1f;
        }
    }

    void FixedUpdate()
    {

        controller.Move(horizontalMove * sprint * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
