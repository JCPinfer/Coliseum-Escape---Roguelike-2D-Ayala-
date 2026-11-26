using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AntorchaAnimationScript : MonoBehaviour
{
    [Header("Configuración de la Llama")]
    [SerializeField] private Light2D luzAntorcha;
    [SerializeField] private float intensidadMinima = 0.8f;
    [SerializeField] private float intensidadMaxima = 1.4f;
    [SerializeField] private float velocidadParpadeo = 5f;

    private float semillaAleatoria;

    private void Start()
    {
        if (luzAntorcha == null)
            luzAntorcha = GetComponent<Light2D>();

        semillaAleatoria = Random.Range(0f, 100f);
    }

    private void Update()
    {
        float ruido = Mathf.PerlinNoise(semillaAleatoria, Time.time * velocidadParpadeo);

        luzAntorcha.intensity = Mathf.Lerp(intensidadMinima, intensidadMaxima, ruido);
    }
}