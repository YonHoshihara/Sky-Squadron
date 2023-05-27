using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemy;
    
    [SerializeField]
    private Transform leftWall;

    [SerializeField]
    private Transform rightWall;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 0f, 2.5f);
    }

    void CreateEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(leftWall.position.x, rightWall.position.x), 0f, rightWall.position.z);
        Instantiate(enemy, pos, Quaternion.identity);
        enemy.transform.localPosition = pos;
    }

}
