using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Health = 3;
    public PlayerController playerhealth;
    public Transform PlayerPosition;
    public Transform EnemyPosition;
    public Transform AttackPos;
    public LayerMask PlayerLayer;
    public float RangeX;
    public float RangeY;
    public int Damage;
    public Vector2 velocity;
    public float StartDazedTime;
    private float DazedTime;
    private RaycastHit2D GroundInfo;
    private float TimeAttack;
    public float StartTimeAttack;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(playerhealth.health == 0)
        {
            return;
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            if (DazedTime <= 0)
            {
                velocity.x = 1;
            }
            else
            {
                velocity.x = 0;
                DazedTime -= Time.deltaTime;
            }

            if ((PlayerPosition.position.x <= EnemyPosition.position.x) &&
                Mathf.Abs((PlayerPosition.position.y - EnemyPosition.position.y)) < 1.5f &&
                Mathf.Abs((PlayerPosition.position.x - EnemyPosition.position.x)) < 2.9f)
            {
                transform.Translate((-velocity * Time.deltaTime) * 0.75f);
            }
            else if ((PlayerPosition.position.x >= EnemyPosition.position.x)
                && Mathf.Abs((PlayerPosition.position.y - EnemyPosition.position.y)) < 1.5f &&
                Mathf.Abs((PlayerPosition.position.x - EnemyPosition.position.x)) < 2.9f)
            {
                transform.Translate((velocity * Time.deltaTime) * 0.75f);
            }
            if (TimeAttack <= 0)
            {
                if (Mathf.Abs((PlayerPosition.position.y - EnemyPosition.position.y)) < 1f && Mathf.Abs(PlayerPosition.position.x - EnemyPosition.position.x) < 1f)
                {
                    Collider2D PlayerToDamage = Physics2D.OverlapBox(AttackPos.position, new Vector2(RangeX, RangeY), 0, PlayerLayer);
                    if (playerhealth != null || gameObject != null)
                    {
                        try
                        {
                            PlayerToDamage.GetComponent<PlayerController>().GetDamage(1);
                        }
                        catch (Exception)
                        {
                            Debug.Log("Miss!");
                        }

                    }
                }
                TimeAttack = StartTimeAttack;
            }
            else
            {
                TimeAttack -= Time.deltaTime;
            }
        }
        
	}

    public void TakeDamage(int damage)
    {
        DazedTime = StartDazedTime;
        if(PlayerPosition.position.x > EnemyPosition.position.x)
        {
            transform.Translate(Vector2.left * 0.4f);
        }
        else
        {
            transform.Translate(Vector2.right * 0.4f);
        }
        Health -= damage;
    }
}
