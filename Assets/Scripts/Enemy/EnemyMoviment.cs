using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    private bool movingDown = true;
    private float speed = 0.5f;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}