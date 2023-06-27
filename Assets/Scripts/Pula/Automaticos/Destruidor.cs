using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Plataforma")
            Destroy(other.gameObject);
        else
        {
            Cam.seguir = false;
        }
    }
}
