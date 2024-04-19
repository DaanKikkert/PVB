using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public float detectionRadius = 10f;

    [SerializeField] private float updateDelay = 0.2f;
    
    [SerializeField] private EnemyReferences _enemyReferences;
        
    [SerializeField] private LayerMask _playerLayer;
    
    private Transform _enemyTarget;

    private float _timer;

    private void Update()
    {
        DetectPlayers();
        UpdateTarget();
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

    private void ResetTargetToMainBase()
    {
        _enemyTarget = _enemyReferences.mainBase.transform;
    }

    private void UpdateTarget()
    {
        _timer += Time.deltaTime;
        if (_timer >= updateDelay)
        {
            _enemyReferences.movement.SetTarget(_enemyTarget);
            _timer = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}