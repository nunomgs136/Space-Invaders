using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int pontos = 0;
    public int vidas = 3;

    public bool venceu = false;

    public int inimigosRestantes = 20;

    private TMP_Text textoPontos;
    private TMP_Text textoVidas;

void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject); // ← sobrevive à troca de cena!
}

void Start()
{
    // Rebusca os textos na cena atual (necessário após trocar de cena)
    textoPontos = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    textoVidas  = GameObject.Find("VidasText").GetComponent<TMP_Text>();

    inimigosRestantes = GameObject.FindGameObjectsWithTag("Invaders").Length;

    AtualizarUI();
}

    public void InimigoDestruido()
    {
        pontos++;
        inimigosRestantes--;

        textoPontos.text = "Pontos: " + pontos;

        // venceu o jogo
        if (inimigosRestantes <= 0)
        {
            venceu = true;
            SceneManager.LoadScene("TelaFinal");
        }
    }

    public void PlayerAtingido()
    {
        vidas--;
        textoVidas.text = "Vidas: " + vidas;

        if (vidas <= 0)
        {
            venceu = false;
            SceneManager.LoadScene("TelaFinal");
        }
    }

    public void AtualizarUI()
    {
        textoPontos.text = "Pontos: " + pontos;
        textoVidas.text  = "Vidas: " + vidas;
    }
}