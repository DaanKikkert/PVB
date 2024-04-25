using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField]private CharacterController characterController;
    [SerializeField]private Transform body;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask ignoredLayers;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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
        
        //Ugly fix for an issue causing the player to be moved up, needs to be changed
        //gameObject.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        
        Vector3 direction = new Vector3(horizontalInput,0f ,  verticalInput);
        characterController.Move(direction * (moveSpeed * Time.deltaTime));
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
