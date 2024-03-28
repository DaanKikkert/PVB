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
    
    public class EnemyMovement : MonoBehaviour
    {

        [Header("Enemy Movement Settings: ")] 
        [SerializeField] private EnemyStates getStates;
        [SerializeField] private NavMeshAgent enemyAgent;
        [SerializeField] private Transform mainStructure;

        [Header("Range Settings: ")] 
        [SerializeField] private float targetRange;
        [SerializeField] [Range(0,5)] private float attackRange;

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
            StartCoroutine(DealDamage(4, 15));

            if (_currentTarget == null)
            {
                getStates = EnemyStates.Target;
                GetTarget(mainStructure);
            }

            if (Vector3.Distance(transform.position, _currentTarget.position) >= attackRange)
            {
                getStates = EnemyStates.Target;
                GetTarget(_currentTarget);
            }
        }

        private IEnumerator DealDamage(int delay, int damage)
        {
            if (!_isWaiting)
            {
                _isWaiting = true;
                _currentTarget.GetComponent<DepleteHealth>().health -= damage;
                if (_currentTarget.GetComponent<DepleteHealth>().health <= 0)
                    Destroy(_currentTarget.gameObject);
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
