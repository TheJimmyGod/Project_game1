using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject m_Enemy;
    public Transform Enemypos;
    void Start()
    {
        Invoke("EnemySpawner", 1f);
    }
    void EnemySpawner()
    {
        
        Instantiate(m_Enemy, Enemypos.position, Enemypos.rotation);
    }
}
