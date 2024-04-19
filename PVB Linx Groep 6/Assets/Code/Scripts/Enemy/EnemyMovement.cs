using System.Collections;
using UnityEngine;
using UnityEngine.AI;



public class EnemyMovement : MonoBehaviour
{
    public bool isInRange = false;

    [SerializeField] private float moveSpeed = 5f;
    
    [Tooltip("The distance the enemy stops from its target")]
    [SerializeField] private float stopDistance = 10f;
    
    [Tooltip("The delay between checks for target position")]
    [SerializeField] private float updateDelay = 0.2f;
    
    [Tooltip("The time an enemy waits before stopping when conditions are met, to avoid it getting caught behind corners")]
    [SerializeField] private float stopDelay = 0.2f;

    [Tooltip("How quickly the enemy should rotate towards its target")]
    [SerializeField] private float lookSpeed = 5f;
    
    [SerializeField] private EnemyReferences references;
    
    private Vector3 _targetPosition;
    private NavMeshAgent _navMeshAgent;

    private float targetDistance;
    
    private bool _isChasingTarget = false;
    private Transform _targetTransform;

    private float _timer;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _targetTransform = references.mainBase.transform;
        _targetPosition = _targetTransform.position;
        _navMeshAgent.enabled = true;
        _navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {
        if (!_navMeshAgent.enabled)
            return;

        if (_isChasingTarget)
            UpdateTarget();
        

        targetDistance = Vector3.Distance(_targetPosition, transform.position);
        if (targetDistance <= stopDistance) 
            FaceTarget();
        else
        {
            _isChasingTarget = true;
            isInRange = false;
        }
    }

    void UpdateTarget()
    {
        _timer += Time.deltaTime;
        if (_timer >= updateDelay)
        {
            _targetPosition = _targetTransform.position;
            _navMeshAgent.destination = _targetPosition; 
            _timer = 0f;
        }
    }

    public void CheckLineOfSight()
    {
        _targetPosition = _targetTransform.position;
        RaycastHit hit;
        bool canSeePlayer = Physics.Raycast(transform.position, _targetTransform.position - transform.position, out hit);
        Debug.DrawRay(transform.position, _targetTransform.position - transform.position, Color.red);
        
        if (hit.collider != null && hit.collider.CompareTag("Player") || hit.collider.CompareTag("Castle"))
        {
            _isChasingTarget = false;
            StartCoroutine(StopMove(stopDelay));
            isInRange = true;
        }
        else
        {
            _isChasingTarget = true;
            isInRange = false;
        }
        
    }

    public void FaceTarget()
    {
        CheckLineOfSight();
        var targetRotation = Quaternion.LookRotation(_targetTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    }

    IEnumerator StopMove(float waitTime)
    {
        {
            yield return new WaitForSeconds(waitTime);
            _navMeshAgent.destination = gameObject.transform.position;
        }
    }

    public void SetTarget(Transform target)
    {
        _targetTransform = target;
        _targetPosition = _targetTransform.position;
        _navMeshAgent.SetDestination(_targetPosition);
        _isChasingTarget = true;
    }
}
