using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] arvore;

    public GameObject macaco;

    public GameObject cloneMacaco;

    public List<GameObject> macacosObjects;

    public GameObject[] predador;

    public List<Ambiente> ambientes;

    public List<Macaco> macacos;

    public List<Predador> predadores;


    public void InstanciarAmbiente()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Ambiente ambiente = new Ambiente
                {
                    posX = i,
                    posY = j
                };
                ambiente.setPosReal();
                ambientes.Add(ambiente);
            }
        }

        for (int i = 0; i < arvore.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int x = Random.Range(0, 99);
                InstanciarObjetos(ambientes[x].posReal, arvore[i]);
            }
        }

        InstanciarAnimais();

        InvokeRepeating("Movimenta", 3f, 3f);

        Debug.Log("qualquer coisa depois");
    }

    private void InstanciarAnimais()
    {
        int i = 10;
        while (i != 0)
        {
            int pos = Random.Range(0, 99);
            if (ambientes[pos].macaco == null)
            {
                Macaco m = new Macaco
                {
                    posX = ambientes[pos].posX,
                    posY = ambientes[pos].posY,
                    posReal = ambientes[pos].posReal

                };
                ambientes[pos].macaco = m;
                macacos.Add(m);
                InstanciarMacacos(m.posReal, macaco);
                i--;
            }
        }
        
        for (int j = 0; j<3; j++)
        {
            int r = Random.Range(0, 99);
            if (ambientes[r].macaco == null)
            {
                Predador p = new Predador
                {
                    posX = ambientes[r].posX,
                    posY = ambientes[r].posY,
                    posReal = ambientes[r].posReal
                };
                ambientes[r].predador = p;
                InstanciarObjetos(p.posReal, predador[j]);
            } else 
            {
                j--;
            }
        }
    }

    private void InstanciarObjetos(Vector3 pos, GameObject go)
    {
        Instantiate(go, pos, go.transform.rotation);
    }

    private void InstanciarMacacos(Vector3 pos, GameObject go)
    {
        cloneMacaco = Instantiate(go, pos, go.transform.rotation);
        macacosObjects.Add(cloneMacaco);
    }

    public void Atualiza()
    {
        InvokeRepeating("Movimenta", 3f, 3f);
    }

    public void Movimenta()
    {
        int numMacacaos = macacosObjects.Count();
        int i = 0;
        foreach(Macaco m in macacos)
        {
            ambientes.FirstOrDefault(x => x.posX == m.posX && x.posY == m.posY).macaco = null;
            Movimentacao movimentacao = new Movimentacao { };
            Vetor vet = movimentacao.AtualizaPosicao(m);
            ambientes.FirstOrDefault(x => x.posX == vet.x && x.posY == vet.y).macaco = m;
            m.posX = vet.x;
            m.posY = vet.y;
            m.posReal = ambientes.FirstOrDefault(x => x.posX == vet.x && x.posY == vet.y).posReal;
            Move(macacosObjects[i], m.posReal);
            i++;
            Debug.Log("Ok3");
        }  
    }

    public void Move(GameObject gameObject, Vector3 posicao)
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, posicao, 0.5f);
    }
}
