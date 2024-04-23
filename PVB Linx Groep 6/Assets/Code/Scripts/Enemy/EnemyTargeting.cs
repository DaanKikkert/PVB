using System;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public float detectionRadius = 10f;
    
    [Tooltip("The delay between checks for target position")]
    [SerializeField] private float updateDelay = 0.2f;
    
    [Tooltip("Set this to false if you never want the enemy to target the player")]
    [SerializeField] private bool _targetsPlayer = true;

    [SerializeField] private LayerMask _playerLayer;
    
    private Transform _enemyTarget;
    
    private Transform _targetPosition;

    private EnemyReferences _references;
    
    private float _timer;

    private void Start()
    {
        _references = GetComponent<EnemyReferences>();
        ResetTargetToMainBase();
    }

    private void Update()
    {
        if (_targetsPlayer)
        {
            DetectPlayers();
            UpdateTarget();
            GetNearestTargetPosition(_enemyTarget);
        }
    }

    private void DetectPlayers()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, _playerLayer);

        if (colliders.Length > 0)
        {
            SetNearestPlayerAsTarget(colliders);
        }
        else
        {
            ResetTargetToMainBase();
        }
    }

    private void SetNearestPlayerAsTarget(Collider[] colliders)
    {
        float shortestDistance = Mathf.Infinity;
        Transform nearestPlayer = null;

        foreach (Collider collider in colliders)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, collider.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = collider.transform;
            }
        }

        _enemyTarget = nearestPlayer;
    }

    private void GetNearestTargetPosition(Transform target)
    {
        int layerA = 6; 
        int layerB = 8;
        int layerMask = (1 << layerA) | (1 << layerB);
        RaycastHit hit;
        Physics.Raycast(transform.position, target.position - transform.position, out hit, Mathf.Infinity, layerMask);
        _targetPosition.position = hit.point;
    }

    private void ResetTargetToMainBase()
    {
        _enemyTarget = _references.mainBase.transform;
    }

    private void UpdateTarget()
    {
        _timer += Time.deltaTime;
        if (_timer >= updateDelay)
        {
            _references.movement.SetTarget(_targetPosition);
            _timer = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}