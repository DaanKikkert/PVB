using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Player;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField]private Rigidbody rb;
    [SerializeField]private Transform body;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask ignoredLayers;
    [SerializeField] private Animator playerAnim;

    private Vector3 _dirVector;

    public Vector3 GetDirection()
    {
        return _dirVector;
    }

    void FixedUpdate()
    {
        HandlePlayerMovement();
        HandlePlayerTurning();
    }
    private void HandlePlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        _dirVector = new Vector3(horizontalInput,0f ,  verticalInput);
        rb.MovePosition((Vector3)transform.position + (_dirVector * (moveSpeed * Time.deltaTime)));

        playerAnim.SetBool("IsWalking", _dirVector.magnitude > 0.01f);
    }

    private void HandlePlayerTurning()
    {
        bool success = GetMousePosition().success;
        Vector3 position = GetMousePosition().position;
        if (success)
        {
            Vector3 direction = position - transform.position;
            direction.y = 0;
            body.forward = direction;
        }
    }
    
    private (bool success, Vector3 position) GetMousePosition()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ~ignoredLayers))
            return (success: true, position: hitInfo.point);
        else
            return (success: false, position: Vector3.zero);
    }

}