using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Camera _minimapCam;

    [SerializeField] private float _maxZoomSize;
    [SerializeField] private float _minZoomSize;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9) && _minimapCam.orthographicSize <= _maxZoomSize)
            _minimapCam.orthographicSize += 0.25f;

        if (Input.GetKeyDown(KeyCode.Minus) && _minimapCam.orthographicSize >= _minZoomSize)
            _minimapCam.orthographicSize -= 0.25f;
    }
}
