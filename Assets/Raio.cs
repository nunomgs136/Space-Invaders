using UnityEngine;

public class Raio : MonoBehaviour
{
   public float velocidade = 15f;

    void Update()
    {
        // Movimento vertical
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Invaders"))
        {
            Destroy(col.gameObject); // destrói inimigo
            Destroy(gameObject);     // destrói o raio
        }
    }
}
