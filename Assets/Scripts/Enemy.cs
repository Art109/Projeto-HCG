using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]protected float speed, dano;
    public int life;



    public void Movement() 
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
        }
    }

    public void Die() 
    { 
        if(life <= 0) 
        { 
            Destroy(gameObject);
        }
    }



 
}
