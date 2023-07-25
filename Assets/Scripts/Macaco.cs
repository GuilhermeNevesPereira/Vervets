using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macaco : MonoBehaviour
{
    public string nome { get; set; }
    public int posX { get; set; }
    public int posY { get; set; }
    public Vector3 posReal { get; set; }

    private GameObject[] objetosClonados;
    void Update()
    {
        
    }

    public void DetectaAnimais()
    {
        objetosClonados = GameObject.FindGameObjectsWithTag("Player");
    }

    public void Move(Vector3 posicao)
    {
        transform.position = Vector3.MoveTowards(transform.position, posicao, 0.5f);
    }
}
