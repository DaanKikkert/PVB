using UnityEngine;

public sealed class EnemyReferences : MonoBehaviour
{
    [HideInInspector] public GameObject mainBase;
    [HideInInspector] public EnemyMovement movement;
    [HideInInspector] public EnemyTargeting targeting;
    [HideInInspector] public Experience getExperience;
    public Animator animator;

    private void Awake()
    {
        mainBase = GameObject.FindWithTag("Castle");
        movement = GetComponent<EnemyMovement>();
        targeting = GetComponent<EnemyTargeting>();
        getExperience = FindObjectOfType<Experience>();
        animator = GetComponentInChildren<Animator>();
    }

    public void AddExperience(float experience) => getExperience.AddExperience(experience);
}
