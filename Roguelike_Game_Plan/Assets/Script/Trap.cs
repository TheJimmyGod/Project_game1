using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D PlayerToDamage = Physics2D.OverlapCircle(gameObject.transform.position, 0.5f);
        if (collision.CompareTag("Player"))
        {
            try
            {
                PlayerToDamage.GetComponent<PlayerController>().GetDamage(6);
                Debug.Log("Ouch!");
            }
            catch(Exception)
            {
                PlayerToDamage = null;
            }
        }
    }
}
