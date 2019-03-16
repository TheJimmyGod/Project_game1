using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform Target;

    private void Start()
    {
        Target = GameObject.Find("Player").transform;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(Target.position.x, xMin, xMax), Mathf.Clamp(Target.position.y, yMin, yMax), transform.position.z);
    }

}
