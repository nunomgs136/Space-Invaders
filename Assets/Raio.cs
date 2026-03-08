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
    //Debug.Log("Raio colidiu com: " + col.gameObject.name + " | Tag: " + col.gameObject.tag);

    if (!tiroInimigo && col.CompareTag("Invaders"))
    {
        gameManager.instance.InimigoDestruido();
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

    if (!tiroInimigo && col.CompareTag("NaveMae"))
    {
    Debug.Log("BATEU NA MÃE, QUE COISA FEIA!");
    col.GetComponent<NaveMae>().AcertouNaveMae();
    Destroy(gameObject);
    }

    if (tiroInimigo && col.CompareTag("Player"))
    {
        gameManager.instance.PlayerAtingido();
        Destroy(gameObject);
    }

    // Destrói o raio ao sair pela parede superior
    if (!tiroInimigo && col.CompareTag("TopWall"))
        Destroy(gameObject);
}
}