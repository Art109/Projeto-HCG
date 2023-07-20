using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ExpOrb : MonoBehaviour, IInteractable
{
    [SerializeField] int exp;
    public void Interaction()
    {
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().exp += exp;
    }

}
