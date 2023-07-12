using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        movementInput = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized * speed;

        rb.velocity = movementInput;
    }
}
