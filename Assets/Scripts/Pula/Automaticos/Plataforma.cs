using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public enum tipoDePulo { Normal, Mola, Some}

    [Header("Configurações")]
    [SerializeField] private GameObject mola;
    [SerializeField] private bool inicial;
    [SerializeField] private float forcaPuloNormal; 
    [SerializeField] private float forcaPuloMola, velocidadeMovel;
    [SerializeField] private Sprite[] sprite;
    private GameObject jogador, construtor;
    private float lado = 1;
    private int canoPorc;
    public tipoDePulo tipoPulo;
    public bool movel;

    private Rigidbody2D rbJogador;

    void Start()
    {
        if (!inicial)
        {
            canoPorc = Random.Range(0, 100);
            if (canoPorc < 15)
            {
                tipoPulo = tipoDePulo.Mola;
            }
            else if (canoPorc < 30)
            {
                tipoPulo = tipoDePulo.Some;
            }
            else
            {
                tipoPulo = tipoDePulo.Normal;
            }
            this.GetComponent<SpriteRenderer>().sprite = (tipoPulo == tipoDePulo.Normal ? sprite[0] : (tipoPulo == tipoDePulo.Some ? sprite[1] : sprite[0]));
            mola.SetActive(tipoPulo == tipoDePulo.Mola);
        }
        jogador = GameObject.FindWithTag("Player");
        construtor = GameObject.FindWithTag("Construtor");
        rbJogador = jogador.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(movel)
            MoverPlataforma(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && rbJogador.velocity.y <= 0)
        {
            if (tipoPulo == tipoDePulo.Mola)
            {
                mola.GetComponent<Animator>().SetTrigger("Pula");
            }
            switch (tipoPulo)
            {
                case tipoDePulo.Normal:
                    Pulo(forcaPuloNormal);
                    break;
                case tipoDePulo.Mola:
                    Pulo(forcaPuloMola);
                    break;
                case tipoDePulo.Some:
                    Pulo(forcaPuloNormal);
                    this.GetComponent<Animator>().SetTrigger("Apaga");
                    break;
            }
        }
    }

    /// <summary>
    /// Faz jogador pular
    /// </summary>
    /// <param name="forcaPulo">Força do pulo</param>
    private void Pulo(float forcaPulo)
    {
        rbJogador.velocity = new Vector2(rbJogador.velocity.x, forcaPulo);
    }

    private void MoverPlataforma()
    {
        this.transform.Translate(Vector2.right * velocidadeMovel * lado);
        if (this.transform.position.x >= construtor.GetComponent<Cenario>().xMax)
        {
            lado = -1;
        }
        else if (this.transform.position.x <= -construtor.GetComponent<Cenario>().xMax)
        {
            lado = 1;
        }
    }

    private void Destroir()
    {
        Destroy(this.gameObject);
    }
}
