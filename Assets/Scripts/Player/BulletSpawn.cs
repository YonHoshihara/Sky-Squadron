using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab da bala
    public Transform spawnPoint; // Ponto de origem da bala
    public float spawnInterval = 1f; // Intervalo de tempo entre cada spawn de bala

    private float timer = 0f; // Temporizador para controlar os spawns

    private void Update()
    {
        timer += Time.deltaTime;

        // Verificar se é hora de spawnar uma bala
        if (timer >= spawnInterval)
        {
            SpawnBullet();
            timer = 0f;
        }
    }

    private void SpawnBullet()
    {
        // Instanciar a bala a partir do prefab
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
