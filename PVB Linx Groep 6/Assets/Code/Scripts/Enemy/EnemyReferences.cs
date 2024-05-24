using UnityEngine;

public sealed class EnemyReferences : MonoBehaviour
{
    [HideInInspector] public GameObject mainBase;
    [HideInInspector] public EnemyMovement movement;
    [HideInInspector] public EnemyTargeting targeting;
    [HideInInspector] public Experience experience;
    public Animator animator;

    private void Awake()
    {
        mainBase = GameObject.FindWithTag("Castle");
        experience = GameObject.FindWithTag("Experience").GetComponent<Experience>();
        movement = GetComponent<EnemyMovement>();
        targeting = GetComponent<EnemyTargeting>();
        animator = GetComponentInChildren<Animator>();
    }
}
