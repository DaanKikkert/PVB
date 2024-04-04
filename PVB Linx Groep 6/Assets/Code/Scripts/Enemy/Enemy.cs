using System.Collections;
using Code.Scripts.Health;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Code.Scripts.Enemy
{

    public enum EnemyStates
    {
        Target,
        Move,
        Attack
    }
    
    public class Enemy : MonoBehaviour
    {

        [Header("Enemy Movement Settings: ")] 
        [SerializeField] private EnemyStates getStates;
        [SerializeField] private NavMeshAgent enemyAgent;
        [SerializeField] private Transform mainStructure;

        [Header("Range Settings: ")] 
        [SerializeField] private float targetRange;
        [SerializeField] [Range(0,5)] private float attackRange;

        [Header("Scale able Attack Settings: ")]
        [SerializeField] private int delay;
        [SerializeField] private int damage;
        
        private Transform _currentTarget;
        private bool _hasFoundPlayer;
        private bool _isWaiting;
        
        // Start is called before the first frame update
        private void Start()
        {
            getStates = EnemyStates.Target;
            _currentTarget = mainStructure;
        }

        // Update is called once per frame
        private void Update()
        {
            switch (getStates)
            {
                case EnemyStates.Target when !_hasFoundPlayer:
                    GetTarget(_currentTarget);
                    break;
                case EnemyStates.Move:
                    MoveTowardsTarget();
                    break;
                case EnemyStates.Attack:
                    AttackTarget();
                    break;
            }
        }

        private void GetTarget(Transform getTarget)
        {
            if (_hasFoundPlayer)
            {
                _currentTarget = getTarget;
                getStates = EnemyStates.Move;
            }
            else
            {
                GameObject[] structures = GameObject.FindGameObjectsWithTag("Structure"); 
                float shortestDis = Mathf.Infinity;
                Transform nearestStructure = null;

                foreach (var structureObj in structures)
                {
                    Transform structure = structureObj.transform;
                    float distance = Vector3.Distance(transform.position, structure.position);
                    if (distance < shortestDis)
                    {
                        shortestDis = distance;
                        nearestStructure = structure;
                    }
                }

                _currentTarget = nearestStructure;
            }
            
            if (_currentTarget != null)
                getStates = EnemyStates.Move;
        }

        private void MoveTowardsTarget()
        {
            if (_currentTarget != null)
                enemyAgent.SetDestination(_currentTarget.position);

            if (Vector3.Distance(transform.position, _currentTarget.position) <= attackRange)
            {
                getStates = EnemyStates.Attack;
                AttackTarget();
            }
        }

        private void AttackTarget()
        {
            StartCoroutine(DealDamage());

            if (_currentTarget == null)
            {
                getStates = EnemyStates.Target;
                GetTarget(mainStructure);
            }

            if (Vector3.Distance(transform.position, _currentTarget.position) >= attackRange)
            {
                getStates = EnemyStates.Target;
                _currentTarget = mainStructure;
                GetTarget(mainStructure);
                
                if (mainStructure == null)
                {
                    GetTarget(_currentTarget);
                    if (_currentTarget == null)
                        _currentTarget = null;
                }
            }
        }

        private IEnumerator DealDamage()
        {
            if (!_isWaiting)
            {
                _isWaiting = true;
                DepleteHealth targetHealth = _currentTarget.GetComponent<DepleteHealth>();
                if (targetHealth == null)
                    targetHealth = _currentTarget.GetComponentInChildren<DepleteHealth>();
                
                targetHealth.health -= damage;
                targetHealth.CheckHealth();
                yield return new WaitForSeconds(delay);
                _isWaiting = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                getStates = EnemyStates.Target;
                _hasFoundPlayer = true;
                GetTarget(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                getStates = EnemyStates.Target;
                _hasFoundPlayer = false;
                GetTarget(_currentTarget);
            }
        }
    }
}
