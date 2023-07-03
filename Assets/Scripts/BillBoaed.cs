using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoaed : MonoBehaviour
{
    private Transform cam;

    public void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    public void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
