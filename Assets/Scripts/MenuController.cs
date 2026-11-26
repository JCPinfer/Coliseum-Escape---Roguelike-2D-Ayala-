using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    [SerializeField] GameObject menuPrincipal;
    [SerializeField] GameObject info;

    void Start()
    {
        menuPrincipal.SetActive(true);
        info.SetActive(false);
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Volver()
    {
        menuPrincipal.SetActive(true);
        info.SetActive(false);
    }

    public void Info()
    {
        menuPrincipal.SetActive(false);
        info.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
    }
}