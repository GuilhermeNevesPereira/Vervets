using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiente : MonoBehaviour
{
    public enum EnvironmentType
    {
        HT, // High Tree
        MT, // Medium Tree
        LT  // Low Tree
    };

    // Atributos do ambiente
    public EnvironmentType type { get; set; }
    public int posX { get; set; }
    public int posY { get; set; }
    public Vector3 posReal { get; set; }
    public Macaco macaco { get; set; }
    public Predador predador { get; set; }

    public void setPosReal()
    {
        posReal = new Vector3
        {
            x = (posX+1) * 0.75f - 0.375f,
            y = (posY+1) * 0.75f - 0.375f,
            z = 0
        };
    }


}
