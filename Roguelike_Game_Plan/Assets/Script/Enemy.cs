using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Health = 4;
    public Transform PlayerPosition;
    public Transform EnemyPosition;
    public Vector2 velocity;
    private int randomMove;
    private float Times;
    private float changing_time = 1.0f;
    private RaycastHit2D GroundInfo;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        velocity.x = 5;
        if (Times <= 0)
        {
            Times = changing_time;
            randomMove = Random.Range(-1, 1);
        }
        else
        {
            Times -= Time.deltaTime;
        }
        
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        if((PlayerPosition.position.x <= EnemyPosition.position.x) && 
            Mathf.Abs((PlayerPosition.position.y - EnemyPosition.position.y)) < 1.5f &&
            Mathf.Abs((PlayerPosition.position.x - EnemyPosition.position.x)) < 2.9f)
        {
            transform.Translate(-velocity * Time.deltaTime);
        }
        else if((PlayerPosition.position.x >= EnemyPosition.position.x) 
            && Mathf.Abs((PlayerPosition.position.y - EnemyPosition.position.y)) < 1.5f &&
            Mathf.Abs((PlayerPosition.position.x - EnemyPosition.position.x)) < 2.9f)
        {
            transform.Translate(velocity * Time.deltaTime);
        }
        else
        {
            if(randomMove < 0)
            {
                transform.Translate(-velocity * 0.5f *Time.deltaTime);
            }
            else
            {
                transform.Translate(velocity * 0.5f * Time.deltaTime);
            }
        }
	}
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
