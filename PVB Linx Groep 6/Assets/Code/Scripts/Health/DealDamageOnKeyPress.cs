using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using UnityEngine;

public class DealDamageOnKeyPress : MonoBehaviour
{
    [SerializeField] private UniversalHealth health;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health.TakeDamage(10);
        }
    }
}
