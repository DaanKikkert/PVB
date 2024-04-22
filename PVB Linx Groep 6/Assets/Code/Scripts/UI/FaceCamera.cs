using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private GameObject mainCamera;

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
