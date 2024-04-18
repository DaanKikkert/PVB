using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    
    private Vector3 _targetPosition;
    private NavMeshAgent _navMeshAgent;

    private float targetDistance;
    [SerializeField] private float stopDistance = 10f;
    
    [SerializeField] private float updateDelay = 0.2f;
    [SerializeField] private float detectionDelay = 0.2f;
    [SerializeField] private float lookSpeed = 5f;
    
    [SerializeField] private EnemyReferences references;
    
    [HideInInspector] public bool isChasingPlayer = false;
    [HideInInspector] public bool movingTowardsTarget = false;

    private float _timer;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        target = references.mainBase.transform;
        _targetPosition = target.position;
        _navMeshAgent.enabled = true;
    }

    private void Update()
    {
        if (!_navMeshAgent.enabled)
            return;

        if (isChasingPlayer)
        {
            UpdateTarget();
        }

        targetDistance = Vector3.Distance(_targetPosition, transform.position);
        if (targetDistance <= stopDistance)
        {
            FaceTarget();
        }
        else
        {
            movingTowardsTarget = true;
        }
    }

    void UpdateTarget()
    {
        _timer += Time.deltaTime;
        if (_timer >= updateDelay)
        {
            _targetPosition = target.position;
            _navMeshAgent.destination = _targetPosition; 
            _timer = 0f;
        }
    }

    public void CheckLineOfSight()
    {
        _targetPosition = target.position;
        RaycastHit hit;
        bool canSeePlayer = Physics.Raycast(transform.position, target.position - transform.position, out hit);
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red);
        
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            isChasingPlayer = false;
            StartCoroutine(StopMove(0.2f));
        }
        else
        {
            isChasingPlayer = true;
        }
        
    }

    public void FaceTarget()
    {
        CheckLineOfSight();

        var targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    }

    IEnumerator StopMove(float waitTime)
    {
        {
            yield return new WaitForSeconds(waitTime);
            _navMeshAgent.destination = gameObject.transform.position;
        }
    }
}
