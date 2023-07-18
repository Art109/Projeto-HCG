using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 movementInput;
    [SerializeField] GameObject Weapon;
    [SerializeField]IWeapon weapon;
    void Start()
    {
        movementInput = new Vector2(0, 0);
        weapon = Weapon.GetComponent<IWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moviemnto
        Movement();

        //Tiro
        Shoot();
    }

    void Movement() 
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized * speed;

        rb.velocity = movementInput;
    }

    void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        weapon.Shoot(mousePos);
    }
}

public interface IWeapon 
{
    void Shoot(Vector3 targetPos);
}
