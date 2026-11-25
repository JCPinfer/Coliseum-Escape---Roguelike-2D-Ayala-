using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool pausado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausado == false)
            {
                pausarJuego();
            } else
            {
                reanudar();
            }
                
        }
    }

    private void pausarJuego()
    {
        Time.timeScale = 0f;
        pausado = true;
    }

    private void reanudar()
    {
        Time.timeScale = 1f;
        pausado = false;
    }

    private void reiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
