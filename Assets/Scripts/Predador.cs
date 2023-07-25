using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Predador : MonoBehaviour
{
    public string nome;
    public int posX { get; set; }
    public int posY { get; set; }
    public Vector3 posReal { get; set; }

    [SerializeField]
    private Transform alvo;

    private GameObject[] objetosClonados;

    void Update()
    {
        DetectaInimigo();
        Debug.Log("ok4");
    }

    public void DetectaInimigo()
    {
        objetosClonados = GameObject.FindGameObjectsWithTag("Player");
        Vector3 posicaoAtual = transform.position;
        Vector3 vetorComum = new Vector3
        {
            x = 0.75f,
            y = 0.75f,
            z = 0
        };
        Vector3 posicaoAtualAjustada = posicaoAtual - vetorComum;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                foreach (GameObject objeto in objetosClonados)
                {
                    if (objeto.transform.position == posicaoAtualAjustada)
                    {
                        this.alvo = objeto.transform;
                    }
                }
                posicaoAtual.x += 0.75f;
            }
            posicaoAtual.y += 0.75f;
        }
        Debug.Log("ok5");
    }
}
