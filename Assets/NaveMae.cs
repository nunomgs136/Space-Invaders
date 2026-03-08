using UnityEngine;

public class NaveMae : MonoBehaviour
{
    public float velocidade = 5f;
    public int pontosBonus = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * velocidade;
    }

    public void AcertouNaveMae()
    {
        gameManager.instance.pontos += pontosBonus;
        gameManager.instance.AtualizarUI();
        Destroy(gameObject);
    }
}