using UnityEngine;

public class Invaderzzzzzz : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Laser"))
    {
        gameManager.instance.pontos++; // soma ponto

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
}