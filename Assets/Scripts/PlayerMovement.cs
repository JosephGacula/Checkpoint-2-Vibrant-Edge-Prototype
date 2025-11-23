using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip jumpSFX;
    

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    float sprint = 1f;


    // Update is called once per frames
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            audioSource.PlayOneShot(jumpSFX);
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


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }



    void FixedUpdate()
    {

        controller.Move(horizontalMove * sprint * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
