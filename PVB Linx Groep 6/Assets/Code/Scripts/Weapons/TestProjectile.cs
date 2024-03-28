using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    [SerializeField] private int damage;
    
    [SerializeField] private float speed;

    [SerializeField] private string tag;


    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //If statement empty as the health system is not ready to be accessed yet
        if(collision.gameObject.CompareTag(tag))
        {
            
        }
        Destroy(this.gameObject);
    }
}
