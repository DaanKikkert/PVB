using UnityEngine;
using UnityEngine.AI;

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
        private bool _foundPlayer;
        
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
                case EnemyStates.Target when !_foundPlayer:
                    GetTarget(_currentTarget);
                    break;
                case EnemyStates.Move:
                    MoveTowardsTarget();
                    break;
                case EnemyStates.Attack:
                    break;
            }
        }

        private void GetTarget(Transform getTarget)
        {
            if (_foundPlayer)
            {
                _currentTarget = getTarget;
                getStates = EnemyStates.Move;
            }
            else
            {
                var structures = GameObject.FindGameObjectsWithTag("Structure");
                var shortestDis = Mathf.Infinity;
                Transform nearestStructure = null;

                foreach (var structureObj in structures)
                {
                    var structure = structureObj.transform;
                    var distance = Vector3.Distance(transform.position, structure.position);
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
                getStates = EnemyStates.Attack;
        }

        private void AttackTarget()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                getStates = EnemyStates.Target;
                _foundPlayer = true;
                GetTarget(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                getStates = EnemyStates.Target;
                _foundPlayer = false;
                GetTarget(mainStructure);
            }
        }
    }
}
