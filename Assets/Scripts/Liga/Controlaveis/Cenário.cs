using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenário : MonoBehaviour
{
    public static RaycastHit2D[] hit;
    public static Canobotao selecionado;

    [SerializeField] GameObject selecionadoBorda, canoReto, canoL;
    [SerializeField] float velocidade;
    [SerializeField] float camMaxX;
    void Update()
    {
        if (Input.touchCount == 2 && Mathf.Abs(Camera.main.transform.position.x) <= camMaxX)
        {
            Camera.main.transform.Translate(Vector2.left * Input.touches[0].deltaPosition.x * velocidade * Time.deltaTime);
        }
        if (Mathf.Abs(Camera.main.transform.position.x) > camMaxX)
        {
            Camera.main.transform.position = new Vector3((Camera.main.transform.position.x < 0? -camMaxX : camMaxX), Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        
        if (selecionado != null)
        {
            selecionadoBorda.transform.position = selecionado.gameObject.transform.position;
        }

        if (Input.touchCount == 1)
        {
            hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            foreach (var item in hit)
            {
                if (selecionado != null && selecionado.quantidade > 0 && item.collider.gameObject.tag ==  "Tabela")
                {
                    switch (selecionado.tipoCano)
                    {
                        case Canobotao.Tipo.L:
                            Instantiate(canoL, item.transform.position, selecionado.gameObject.transform.rotation);
                            break;
                        case Canobotao.Tipo.Reto:
                            Instantiate(canoReto, item.transform.position, selecionado.gameObject.transform.rotation);
                            break;
                    }
                }
            }
        }
    }

}
