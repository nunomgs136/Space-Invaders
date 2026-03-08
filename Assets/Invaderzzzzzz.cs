using UnityEngine;

public class Invaderzzzzzz : MonoBehaviour
{
    public GameObject raioPrefab;
    public float tempoTiro = 3f;

    void Start()
    {
       // InvokeRepeating("Atirar", 2f, tempoTiro);
    }

    /*void Atirar()
    {
        GameObject tiro = Instantiate(raioPrefab, transform.position + Vector3.down * 0.6f, Quaternion.identity);

        Raio scriptRaio = tiro.GetComponent<Raio>();
        scriptRaio.direcao = Vector3.down;
        scriptRaio.tiroInimigo = true;
    } */

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Raio"))
        {
            gameManager.instance.InimigoDestruido();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}