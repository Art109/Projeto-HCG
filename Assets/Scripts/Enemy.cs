using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]float speed, vida, dano;
    Transform playerTransform;

    private void Start()
    {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform ;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() 
    { 
        if(playerTransform.gameObject != null)
        {
            if (playerTransform.position != this.transform.position)
            {

                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            }
        }
        
    }

 
}
