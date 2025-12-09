using UnityEngine;
using UnityEngine.U2D.Animation;


public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform slashPoint;
    public GameObject bulletPrefab;
    public GameObject slashPrefab;

    public Animator animator;
    public AudioSource audioSource;
    public AudioClip shootSFX;
    public AudioClip slashSFX;

    public int weaponType;
    public SpriteResolver resolver;

    // Update is called once per frame

    private void Start()
    {
        resolver = GetComponent<SpriteResolver>();
    }
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("ColorSwitch1"))
            {
                weaponType = 0;
                SetHeadbandColor("Red");
            }

            if (Input.GetButtonDown("ColorSwitch2"))
            {
                weaponType = 1;
                SetHeadbandColor("Green");
            }

            if (Input.GetButtonDown("ColorSwitch3"))
            {
                weaponType = 2;
                SetHeadbandColor("Blue");
            }


            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Shoot");
                audioSource.PlayOneShot(shootSFX);
                Shoot();

            }

            if (Input.GetButtonDown("Fire2"))
            {
                animator.SetTrigger("Slash");
                audioSource.PlayOneShot(slashSFX);
                Slash();
            }
        }
    }

    void Shoot()
    {
        GameObject bulletToDestroy = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        SpriteRenderer sr = bulletToDestroy.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            switch (weaponType)
            {
                case 0:
                    sr.color = Color.red;
                    break;
                case 1:
                    sr.color = Color.green;
                    break;
                case 2:
                    sr.color = Color.blue;
                    break;
            }
        }


        Bullet bulletScript = bulletToDestroy.GetComponent<Bullet>(); //Sets the bullet type
        if (bulletScript != null)
        {
            bulletScript.colorType = weaponType;
        }
        
        
        Destroy(bulletToDestroy, 2f); 
    }

    void Slash()
    {
        GameObject slashToDestroy = Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation);
        SpriteRenderer sr = slashToDestroy.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            switch (weaponType)
            {
                case 0:
                    sr.color = Color.red;
                    break;
                case 1:
                    sr.color = Color.green;
                    break;
                case 2:
                    sr.color = Color.blue;
                    break;
            }


            Slash slashScript = slashToDestroy.GetComponent<Slash>(); //Sets the bullet type
            if (slashScript != null)
            {
                slashScript.slashType = weaponType;
            }


            Destroy(slashToDestroy, 0.1f);

        }
    }

    public void SetHeadbandColor(string colorLabel)
    {
        resolver.SetCategoryAndLabel("Idle", colorLabel);
        resolver.SetCategoryAndLabel("Dash", colorLabel);
        resolver.SetCategoryAndLabel("DashShoot", colorLabel);
        resolver.SetCategoryAndLabel("Shoot", colorLabel);
        resolver.SetCategoryAndLabel("Jump", colorLabel);
        resolver.SetCategoryAndLabel("JumpShoot", colorLabel);
        resolver.SetCategoryAndLabel("Slash", colorLabel);
    }

}
