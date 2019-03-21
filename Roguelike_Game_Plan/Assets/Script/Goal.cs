using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public Transform Object;
    private GameMaster gm;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            gm.Checkpoints = Object.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
