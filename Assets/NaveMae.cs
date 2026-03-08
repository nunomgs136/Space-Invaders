using UnityEngine;

public class NaveMae : MonoBehaviour
{
    public float velocidade = 5f;
    public int pontosBonus = 10;

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    public void AcertouNaveMae()
    {
        gameManager.instance.pontos += pontosBonus;
        gameManager.instance.AtualizarUI();
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}