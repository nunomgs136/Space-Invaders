using UnityEngine;

public class Raio : MonoBehaviour
{
    public float velocidade = 15f;
    public Vector3 direcao = Vector3.up;

    public bool tiroInimigo = false;

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       Debug.Log("Raio colidiu com: " + col.gameObject.name + " | Tag: " + col.gameObject.tag);
         // Tiro do jogador
    if (!tiroInimigo && col.CompareTag("Invaders"))
    {
        gameManager.instance.InimigoDestruido();
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

    // Tiro do jogador acertando a nave mãe
    if (!tiroInimigo && col.CompareTag("NaveMae"))
    {
        Debug.Log("Acertou a NaveMae!");
        col.GetComponent<NaveMae>().AcertouNaveMae();
        Destroy(gameObject);
    }

    // Tiro do inimigo
    if (tiroInimigo && col.CompareTag("Player"))
    {
        gameManager.instance.PlayerAtingido();
        Destroy(gameObject);
    }

        
    }
}