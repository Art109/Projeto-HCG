using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour, IPowerUp
{

    public Vector3 pontoRotacao;
    public Vector3 velocidadeRotacao;
    public void Action()
    {
        transform.Rotate(velocidadeRotacao * Time.deltaTime);
    }

    
  

    private void Update()
    {
        
    }
}
