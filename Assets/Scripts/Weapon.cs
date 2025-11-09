using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform slashPoint;
    public GameObject bulletPrefab;
    public GameObject slashPrefab;

    public int weaponType;

    // Update is called once per frame





    void Update()
    {
        if (Input.GetButtonDown("ColorSwitch1"))
        {
            weaponType = 0;
        }

        if (Input.GetButtonDown("ColorSwitch2"))
        {
            weaponType = 1;
        }

        if (Input.GetButtonDown("ColorSwitch3"))
        {
            weaponType = 2;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Slash();
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
}
