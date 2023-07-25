using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public Vetor AtualizaPosicao (Macaco macaco)
    {
        int posXinicial = macaco.posX;
        int posYinicial = macaco.posY;
        int posicao = VerificarPosicao(posXinicial, posYinicial);
        int posX = 0;
        int posY = 0;

        switch (posicao)
        {
            case 0:
                posX = Random.Range(posXinicial, posXinicial + 2);
                posY = Random.Range(posYinicial, posYinicial + 2);
                break;
            case 1:
                posX = Random.Range(posXinicial, posXinicial + 2);
                posY = Random.Range(posYinicial - 1, posYinicial + 1);
                break;
            case 2:
                posX = Random.Range(posXinicial - 1, posXinicial + 1);
                posY = Random.Range(posYinicial, posYinicial + 2);
                break;
            case 3:
                posX = Random.Range(posXinicial - 1, posXinicial + 1);
                posY = Random.Range(posYinicial -1 , posYinicial + 1);
                break;
            case 4:
                posX = Random.Range(posXinicial - 1, posXinicial + 2);
                posY = Random.Range(posYinicial, posYinicial + 2);
                break;
            case 5:
                posX = Random.Range(posXinicial - 1, posXinicial + 2);
                posY = Random.Range(posYinicial - 1, posYinicial + 1);
                break;
            case 6:
                posX = Random.Range(posXinicial, posXinicial + 2);
                posY = Random.Range(posYinicial - 1, posYinicial + 2);
                break;
            case 7:
                posX = Random.Range(posXinicial - 1, posXinicial + 1);
                posY = Random.Range(posYinicial - 1, posYinicial + 2);
                break;
            case 8:
                posX = Random.Range(posXinicial - 1, posXinicial + 2);
                posY = Random.Range(posYinicial - 1, posYinicial + 2);
                break;
        }

        return new Vetor
        {
            x = posX,
            y = posY
        };
    }

    public int VerificarPosicao(int x, int y)
    {
        // Verifica se é quina
        if (x == 0 && y == 0)
            return 0;

        if (x == 0 && y == 9)
            return 1;

        if (x == 9 && y == 0)
            return 2;

        if (x == 9 && y == 9)
            return 3;

        // Verifica se é lateral esquerda
        if (y == 0)
            return 4;

        // Verifica se é lateral direita
        if (y == 9)
            return 5;

        // Verifica se é lateral cima
        if (x == 0)
            return 6;

        // Verifica se é lateral baixo
        if (x == 9)
            return 7;

        // Se não é nenhuma das posições acima, é meio de matriz
        return 8;
    }
}
