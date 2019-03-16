using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float TimeAttack;
    public float StartTimeAttack;
    public Transform AttackPosition;
    public LayerMask Layer_Enemy;
    public float AttackRangeX;
    public float AttackRangeY;
    public int Damage;
	
	// Update is called once per frame
	void Update () {
		if(TimeAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Collider2D[] EnemiesToDamage = Physics2D.OverlapBoxAll(AttackPosition.position, new Vector2(AttackRangeX,AttackRangeY),0, Layer_Enemy);
                for (int i = 0; i < EnemiesToDamage.Length; i++)
                {
                    EnemiesToDamage[i].GetComponent<Enemy>().TakeDamage(Damage);
                }
                TimeAttack = StartTimeAttack;
            }
            else{
                TimeAttack -= Time.deltaTime;
            }
        }
	}
}
