using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public GameObject Player;
    public Transform Location;
	void Start () {
        Invoke("PlayerSpawner", 0f);
	}

    void PlayerSpawner()
    {
        Instantiate(Player, Location.position, Location.rotation);
    }
}
