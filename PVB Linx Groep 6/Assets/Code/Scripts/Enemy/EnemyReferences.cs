using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyReferences : MonoBehaviour
{
    [HideInInspector] public GameObject mainBase;

    private void Start()
    {
        mainBase = GameObject.FindWithTag("Player");
    }
}
