using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collider2D PlayerToDamage = Physics2D.OverlapCircle(gameObject.transform.position, 0.5f);
            PlayerToDamage.GetComponent<PlayerController>().GetDamage(6);
            Debug.Log("Ouch!");
        }
    }
}
