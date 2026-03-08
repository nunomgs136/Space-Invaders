using UnityEngine;

public class InvaderGroup : MonoBehaviour
{
    public float speed = 5f;
    public Transform LeftWall;
    public Transform RightWall;

    private int moveCount = 0;
    public float dropDistance = 0.5f;
    public float speedIncrease = 1f;

    private float direction = 1f;

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
}