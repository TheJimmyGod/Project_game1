using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float TimeAttack;
    public float StartTimeAttack;
    public Transform AttackPosition;
    public LayerMask Layer_Enemy;
    public Animator PlayerAnimator;
    public PlayerController player;
    public float AttackRangeX;
    public float AttackRangeY;
    public int Damage;
	
	// Update is called once per frame
	void Update () {
        if (TimeAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if(player.IsGrounded == false)
                {
                    PlayerAnimator.SetTrigger("jump_attack");
                }
                else
                {
                    PlayerAnimator.SetTrigger("attack");
                }

                Collider2D[] EnemiesToDamage = Physics2D.OverlapBoxAll(AttackPosition.position, new Vector2(AttackRangeX, AttackRangeY), 0, Layer_Enemy);
                if(player.GetPower >= 6)
                {
                    for (int i = 0; i < EnemiesToDamage.Length; i++)
                    {
                        EnemiesToDamage[i].GetComponent<Enemy>().TakeDamage(Damage*3);
                        Debug.Log("Strong Hit!");
                    }
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health <= 5)
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health++;
                    }
                    player.GetPower = 0;
                }
                else
                {
                    for (int i = 0; i < EnemiesToDamage.Length; i++)
                    {
                        EnemiesToDamage[i].GetComponent<Enemy>().TakeDamage(Damage);
                        Debug.Log("Hit!");
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AttackPosition.position, new Vector3(AttackRangeX, AttackRangeY, 1));
    }
}
