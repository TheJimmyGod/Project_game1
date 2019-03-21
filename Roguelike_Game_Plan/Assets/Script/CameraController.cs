using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float moveSpeed;
    private Vector3 targetPos;
    public PlayerController Player;
    void Start()
    {
        if(!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    void Update()
    {
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            targetPos.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        catch(Exception)
        {
            target = null;
        }
    }

}
