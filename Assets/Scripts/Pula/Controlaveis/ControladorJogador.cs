using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJogador : MonoBehaviour
{
    [Header("Controle")]
    [SerializeField] private float velocidade;
    [SerializeField] private float xMax, xEscala;
    private float horizontalInput;

    [Header("UI")]
    [SerializeField] private GameObject telinhas;
    [SerializeField] private Text altitudeUI;

    [Header("Destruidor")]
    [SerializeField] private GameObject destruidor;

    private int altitudeRecorde;

    private Animator animJogador;
    private Rigidbody2D rbJogador;

    private void Start()
    {
        Time.timeScale = 1;
        animJogador = this.GetComponent<Animator>();
        rbJogador = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Altitude();
        Limite();
        Inputs();
    }

    private void FixedUpdate()
    {
        Animacoes();
        HMovimento();
    }

    private void Animacoes()
    {
        this.transform.localScale = new Vector2((horizontalInput == 0)?this.transform.localScale.x : (horizontalInput < 0)? -xEscala : xEscala,this.transform.localScale.y);
        animJogador.SetBool("Pulando", (rbJogador.velocity.y > 0));
        animJogador.SetBool("Caindo", (rbJogador.velocity.y < 0));
    }

    /// <summary>
    /// Controla os movimentos do jogador
    /// </summary>
    private void Inputs()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        //Teclado
        horizontalInput = Input.GetAxis("Horizontal");
#elif UNITY_ANDROID
        //Acelerometro
        horizontalInput = Input.acceleration.x;

#endif
    }

    /// <summary>
    /// Leva o personagem ao outro lado da tela
    /// </summary>
    private void Limite()
    {
        if (Mathf.Abs(this.transform.position.x) >= xMax)
        {
            this.transform.position = new Vector2(((this.transform.position.x > 0)? -1: 1) * (xMax - 0.2f), transform.position.y);
        }
        if (this.transform.position.y < Camera.main.transform.position.y - 6)
        {
            telinhas.GetComponent<TelinhasScript>().StartCoroutine("Desce", "over");
        }
    }

    /// <summary>
    /// Movimento horizontal do personagem
    /// </summary>
    private void HMovimento()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        //movimento por teclado
        rbJogador.velocity = new Vector2(horizontalInput * velocidade, rbJogador.velocity.y);
#elif UNITY_ANDROID
        //Movimento por acelerometro
        rbJogador.velocity = new Vector2(horizontalInput * velocidade * 1.5f, rbJogador.velocity.y);
#endif
        
    }

    private void Altitude()
    {
        altitudeUI.text = altitudeRecorde.ToString();
        if (Mathf.FloorToInt(this.transform.position.y) > altitudeRecorde)
        {
            altitudeRecorde = Mathf.FloorToInt(this.transform.position.y);
        }
        if (rbJogador.velocity.y > 0 && transform.position.y > altitudeRecorde)
        {
            destruidor.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 6);
            
        }
    }
}
