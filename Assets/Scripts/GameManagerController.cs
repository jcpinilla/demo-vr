using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    private System.Random random;

    void Start()
    {
        random = new System.Random();
        int numberOfEnemies = 2;
        for (int i = 0; i < numberOfEnemies - 1; i++)
        {
            InstantiateEnemy();
        }
    }

    void InstantiateEnemy()
    {
        Vector3 startPosition = RandomSafePosition();
        Instantiate(enemy, startPosition, Quaternion.identity);
    }

    Vector3 RandomSafePosition()
    {
        Vector3 position;
        float distanceToPlayer;
        do
        {
            position = new Vector3(random.Next(-10, 10), random.Next(1, 5), random.Next(-10, 10));
            distanceToPlayer = (position - player.transform.position).magnitude;
        }
        while (distanceToPlayer < 10);
        return position;
    }

    public void OnEnemyHit(GameObject enemy)
    {
        enemy.transform.position = RandomSafePosition();
    }
}
