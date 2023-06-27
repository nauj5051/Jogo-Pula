 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cano : MonoBehaviour
{
    [SerializeField] private Sprite[] canosSprite;
    [SerializeField] private int pontuação = 1;
    private Text contador;
    private GameObject diamante;
    public static int Conta;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = canosSprite[Random.Range(0, canosSprite.Length)];
        contador = GameObject.FindWithTag("Contador").GetComponent<Text>();
        this.gameObject.SetActive(Random.Range(1,5) == 1);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            contador.text = (int.Parse(contador.text) + pontuação).ToString();
            Destroy(this.gameObject);
        }
    }
}
