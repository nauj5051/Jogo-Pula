using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canobotao : MonoBehaviour
{
    public int quantidade;
    public Tipo tipoCano;
    public enum Tipo {L, Reto};

    void Update()
    {
        if (Cenário.hit != null)
        {
            foreach (var item in Cenário.hit)
            {
                if (item.collider.gameObject == this.gameObject)
                {
                    Cenário.selecionado = this;
                }
            }
        }
    }
}
