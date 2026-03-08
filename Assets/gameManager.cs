using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int pontos = 0;
    public int vidas = 3;

    private TMP_Text textoPontos;
    private TMP_Text textoVidas;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Busca os textos na cena pelo nome
        textoPontos = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        textoVidas  = GameObject.Find("VidasText").GetComponent<TMP_Text>();

        AtualizarUI();
    }

    public void InimigoDestruido()
    {
        pontos++;
        textoPontos.text = "Pontos: " + pontos;
    }

    public void PlayerAtingido()
    {
        vidas--;
        textoVidas.text = "Vidas: " + vidas;

        if (vidas <= 0)
            Debug.Log("Game Over");
    }

    public void AtualizarUI()
    {
        textoPontos.text = "Pontos: " + pontos;
        textoVidas.text  = "Vidas: " + vidas;
    }
}