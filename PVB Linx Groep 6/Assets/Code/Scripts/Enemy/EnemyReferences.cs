using UnityEngine;

public sealed class EnemyReferences : MonoBehaviour
{
    [HideInInspector] public GameObject mainBase;
    [HideInInspector] public EnemyMovement movement;
    [HideInInspector] public EnemyTargeting targeting;
    public Animator animator;

    private void Awake()
    {
        mainBase = GameObject.FindWithTag("Castle");
        movement = GetComponent<EnemyMovement>();
        targeting = GetComponent<EnemyTargeting>();
        animator = GetComponentInChildren<Animator>();
    }
}
