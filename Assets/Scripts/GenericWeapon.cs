using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWeapon : MonoBehaviour, IWeapon
{
    public GameObject bulletPrefab;
    public float shootingForce = 10f;
    bool canShoot = true;
    float fireRate = 0.5f;

    public void Shoot(Vector3 targetPos) 
    {
        if (canShoot) 
        {
            Vector3 shootinDir = targetPos - transform.position;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootinDir.normalized * shootingForce, ForceMode2D.Impulse);

            canShoot = false;
            Invoke("ResetShoot", fireRate);
        }
       ;
    }

    private void ResetShoot() 
    {
        canShoot = true;
    }

}
