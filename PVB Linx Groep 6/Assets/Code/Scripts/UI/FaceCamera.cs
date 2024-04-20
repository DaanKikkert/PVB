using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private GameObject mainCamera;

    private void Start()
    {
        //ainCamera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
