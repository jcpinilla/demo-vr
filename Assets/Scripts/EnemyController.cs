using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public GameManagerController gameManagerController;

    void FixedUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed);
    }

    public void OnHit()
    {
        gameManagerController.OnEnemyHit(gameObject);
    }
}
