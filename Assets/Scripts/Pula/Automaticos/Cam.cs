using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Header("Objetos")]
    [SerializeField] private GameObject jogador;
    private Transform transformJogador; 

    [Header("Configurações")]
    [SerializeField] float suavidade;

    public static bool seguir;

    private float ySuavizada;

    private void Start()
    {
        seguir = true;
        transformJogador = jogador.transform;
        this.GetComponent<AudioSource>().mute = MenuInicial.mutoGeral;
    }

    private void FixedUpdate()
    {
        SeguirJogador();
    }

    private void SeguirJogador()
    {
        if (seguir)
        {
            ySuavizada = Mathf.Lerp(this.transform.position.y, transformJogador.position.y + 2, suavidade);
            transform.position = new Vector3(this.transform.position.x, ySuavizada, this.transform.position.z);
        }
    }
}
