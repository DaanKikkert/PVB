using UnityEngine;

public sealed class EnemyReferences : MonoBehaviour
{
    [HideInInspector] public GameObject mainBase;
    [HideInInspector] public EnemyMovement movement;
    [HideInInspector] public EnemyTargeting targeting;

    private void Start()
    {
        mainBase = GameObject.FindWithTag("Castle");
        movement = GetComponent<EnemyMovement>();
        targeting = GetComponent<EnemyTargeting>();
    }
    
    
}
