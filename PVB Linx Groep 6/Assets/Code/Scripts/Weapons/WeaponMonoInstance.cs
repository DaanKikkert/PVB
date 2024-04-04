using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMonoInstance : MonoBehaviour
{
    public static WeaponMonoInstance instance;

    private void Start()
    {
        WeaponMonoInstance.instance = this;
    }
}
