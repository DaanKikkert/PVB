using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Camera _minimapCam;

    [SerializeField] private float _maxZoomSize;
    [SerializeField] private float _minZoomSize;
    [SerializeField][Range(0f,1f)] private float _zoomSizeAdjustAmount;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals) && _minimapCam.orthographicSize <= _maxZoomSize)
            _minimapCam.orthographicSize += _zoomSizeAdjustAmount;

        if (Input.GetKeyDown(KeyCode.Minus) && _minimapCam.orthographicSize >= _minZoomSize)
            _minimapCam.orthographicSize -= _zoomSizeAdjustAmount;
    }
}
