using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanRooms : MonoBehaviour {
    public LayerMask A_Room;
    public LevelGenerator LevelGen;
	void Update () {
        Collider2D RoomDetection = Physics2D.OverlapCircle(transform.position, 1, A_Room);
        if(RoomDetection == null && LevelGen.Stop == true)
        {
            int rand = Random.Range(0, LevelGen.Rooms.Length);
            Instantiate(LevelGen.Rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
