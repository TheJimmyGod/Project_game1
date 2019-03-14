using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Transform[] startingPositions;
    public GameObject[] Rooms;
    private int direction;
    public float MoveAmount;
    private float AutoSpawnRoom;
    public float StartAutoSpawnRoom = 0.05f;

    public float minimumX;
    public float maximumX;
    public float minimumY;
    public bool Stop;

    public LayerMask Room;
    private int DownCounter;
    private void Start()
    {
        int Rand_Starting_Pos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[Rand_Starting_Pos].position;
        Instantiate(Rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if(AutoSpawnRoom <= 0 && Stop == false)
        {
            Move();
            AutoSpawnRoom = StartAutoSpawnRoom;
        }
        else
        {
            AutoSpawnRoom -= Time.deltaTime;
        }
    }
    private void Move()
    {
        if(direction==1||direction==2)
        {
            DownCounter = 0;
            if(transform.position.x < maximumX)
            {
                Vector2 NewPosition = new Vector2(transform.position.x + MoveAmount, transform.position.y);
                transform.position = NewPosition;
                int Rand = Random.Range(0, Rooms.Length);
                Instantiate(Rooms[Rand], transform.position, Quaternion.identity);
                direction = Random.Range(1, 6);
                if(direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if(direction == 3 || direction == 4)
        {
            if(transform.position.x > minimumX)
            {
                DownCounter = 0;
                Vector2 NewPosition = new Vector2(transform.position.x - MoveAmount, transform.position.y);
                transform.position = NewPosition;
                int Rand = Random.Range(0, Rooms.Length);
                Instantiate(Rooms[Rand], transform.position, Quaternion.identity);
                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
        }
        else if(direction == 5)
        {
            DownCounter++;
            if(transform.position.y > minimumY)
            {
                Collider2D RoomDetection = Physics2D.OverlapCircle(transform.position, 1, Room);
                if(RoomDetection.GetComponent<RoomType>().type != 1 && RoomDetection.GetComponent<RoomType>().type != 3)
                {
                    if(DownCounter >= 2)
                    {
                        Instantiate(Rooms[3], transform.position, Quaternion.identity);
                    }
                    RoomDetection.GetComponent<RoomType>().RoomDestuction();
                    int RandBottomRoom = Random.Range(1, 4);
                    if(RandBottomRoom == 2)
                    {
                        RandBottomRoom = 1;
                    }
                    Instantiate(Rooms[RandBottomRoom], transform.position, Quaternion.identity);
                }
                Vector2 NewPosition = new Vector2(transform.position.x, transform.position.y - MoveAmount);
                transform.position = NewPosition;
                int Rand = Random.Range(2,4);
                Instantiate(Rooms[Rand], transform.position, Quaternion.identity);
                direction = Random.Range(1, 6);
            }
            else
            {
                Stop = true;
            }
        }
    }
}
