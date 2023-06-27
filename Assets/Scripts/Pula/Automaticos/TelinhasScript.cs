using System.Collections;
using UnityEngine;

public class TelinhasScript : MonoBehaviour
{
    [SerializeField] private GameObject botaoPause, pauseMenu;
    [SerializeField] private AudioSource gameplay, gameOver;
    public IEnumerator Desce(string tela)
    {
        gameplay.enabled = false;
        gameOver.enabled = true;
        botaoPause.SetActive(false);
        pauseMenu.SetActive(false);
        this.transform.GetChild(0).gameObject.SetActive(tela == "over");
        this.transform.GetChild(1).gameObject.SetActive(!(tela == "over"));
        this.GetComponent<Animator>().SetTrigger("desce");
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }
}
