using UnityEngine;

public class InvaderGroup : MonoBehaviour
{
    public float speed = 5f;
    public Transform LeftWall;
    public Transform RightWall;
    public int quantidadeTiros = 5;
    public GameObject raioPrefab;
    public float tempoTiro = 2f;

    private int moveCount = 0;
    public float dropDistance = 0.5f;
    public float speedIncrease = 1f;

    private float direction = 1f;

    void Start()
    {
        InvokeRepeating("InvaderAtira", 1f, tempoTiro);
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
        CheckWalls();
    }

    void CheckWalls()
    {
        foreach (Transform invader in transform)
        {
            if (invader.position.x >= RightWall.position.x && direction > 0)
            {
                ChangeDirection();
                break;
            }

            if (invader.position.x <= LeftWall.position.x && direction < 0)
            {
                ChangeDirection();
                break;
            }
        }
    }

    void ChangeDirection()
    {
        direction *= -1;
        moveCount++;

        if (moveCount >= 3)
        {
            transform.position += Vector3.down * dropDistance;

            speed += speedIncrease;

            moveCount = 0;
        }
    }

    void InvaderAtira()
    {
        if (transform.childCount == 0) return;

        for (int i = 0; i < quantidadeTiros; i++)
        {
        int index = Random.Range(0, transform.childCount);
        Transform invader = transform.GetChild(index);

        GameObject tiro = Instantiate(raioPrefab, invader.position + Vector3.down * 0.6f, Quaternion.identity);

        Raio scriptRaio = tiro.GetComponent<Raio>();
        scriptRaio.direcao = Vector3.down;
        scriptRaio.tiroInimigo = true;
        }
    }
}