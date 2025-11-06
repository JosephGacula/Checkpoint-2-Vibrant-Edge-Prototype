using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform slashPoint;
    public GameObject bulletPrefab;
    public GameObject slashPrefab;

    // Update is called once per frame
    void Update()
    {
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
        Destroy(bulletToDestroy, 2f);

        
    }

    void Slash()
    {
        GameObject slashToDestroy = Instantiate(slashPrefab, slashPoint.position, slashPoint.rotation);
        Destroy(slashToDestroy, 0.1f);

    }
}
