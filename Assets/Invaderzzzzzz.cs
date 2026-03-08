using UnityEngine;

public class Invaderzzzzzz : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Raio"))
        {
            gameManager.instance.InimigoDestruido();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            gameManager.instance.PlayerAtingido();
            Destroy(gameObject); // ← esse era o problema, faltava destruir o alien
        }
    }
}