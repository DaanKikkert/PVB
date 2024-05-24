using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExperience : MonoBehaviour
{
    private Experience experienceSystem;
    [SerializeField] private float exp;
    
    void Start()
    {
        experienceSystem = GameObject.FindGameObjectWithTag("Experience").GetComponent<Experience>();
    }

    public void AddExp()
    {
        experienceSystem.AddExperience(exp);
    }
}
