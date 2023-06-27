using UnityEngine;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu, botaoPause;
    [SerializeField] private AudioSource musica;
    public static bool mutoGeral;
    public void ChamaHistoria(string cena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(cena);
    }
    public void Pausa(bool pausar)
    {
        Time.timeScale = (pausar? 0 : 1);
        pauseMenu.SetActive(pausar);
        botaoPause.SetActive(!pausar);
    }
    public void Muto(bool muto)
    {
        mutoGeral = muto;
        musica.mute = mutoGeral;
    }
}
