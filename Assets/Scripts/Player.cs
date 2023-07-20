using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Player : MonoBehaviour
{
    IInteractable interaction;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 movementInput;


    [SerializeField] GameObject Weapon;
    [SerializeField]IWeapon weapon;


    public int exp;

    public GameObject serra;

    IPowerUp[] powers;
    void Start()
    {
        movementInput = new Vector2(0, 0);
        weapon = Weapon.GetComponent<IWeapon>();
        powers = new IPowerUp[5];
        Instantiate(serra);
        powers[0] = serra.GetComponent<IPowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moviemnto
        Movement();

        //Tiro
        Shoot();

        //PowerUps
        PowerUps();
    }

    void Movement() 
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized * speed;

        rb.velocity = movementInput;
    }

    void PowerUps()
    {
        if(powers.Length > 0) 
        {
            for(int x = 0; x < powers.Length; x++)
            {
                if(powers[x] == null)
                {
                    return;
                }

                powers[x].Action();
            }
        }
    }

    void Shoot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        weapon.Shoot(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IInteractable>() != null)
        {
            collision.GetComponent<IInteractable>().Interaction();
        }
    }
}

public interface IWeapon 
{
    void Shoot(Vector3 targetPos);
}

public interface IInteractable
{
    void Interaction();
}
public interface IPowerUp
{
    void Action();
}
