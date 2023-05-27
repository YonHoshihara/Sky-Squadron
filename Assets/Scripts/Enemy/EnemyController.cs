using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 0f, 2.5f);
    }

    void CreateEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), 5f, 0);
        Instantiate(enemy, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
