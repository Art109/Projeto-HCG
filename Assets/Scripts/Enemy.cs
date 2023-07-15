using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]protected float speed, vida, dano;
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

    public void Movement() 
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
        }
    }

 
}
