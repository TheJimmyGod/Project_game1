﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int Health;
    public float Speed;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
	}
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
