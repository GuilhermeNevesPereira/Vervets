using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicializar : MonoBehaviour
{

    public SpawnScript iniciarAmbiente;

    void Start()
    {

    }

    public void Play()
    {
        iniciarAmbiente.InstanciarAmbiente();
        Debug.Log("Ok");
    }
}
