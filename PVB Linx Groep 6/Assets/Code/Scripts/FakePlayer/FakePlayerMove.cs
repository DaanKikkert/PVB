using Code.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FakePlayerMove : MonoBehaviour
{
    [SerializeField] private FakePlayerAttack attack;
    [SerializeField] private int offset;
    [SerializeField] private float walkRadius;
    [SerializeField] private float delayBetweenLocations;
    public FakePlayerState state;
    public NavMeshAgent agent;
    private Vector3 _destination;
    private float _timer;
    private BoxCollider _collider;
    private Transform _target;
    private void Awake()
    {
        state = FakePlayerState.Scouting;
        GoScouting();
        PingSystem.onPing.AddListener(MoveToPingArea);
        _collider = GetComponent<BoxCollider>();
    }
    public void MoveToPingArea()
    {
        int xOffset = Random.Range(offset * -1, offset);
        int zOffset = Random.Range(offset * -1, offset);
        Vector3 goToLocation = PingSystem.LastMousePosition();
        goToLocation.x += xOffset;
        goToLocation.z += zOffset;
        agent.destination = goToLocation;
        _destination = goToLocation;
        state = FakePlayerState.Pinged;
        StartCoroutine(ReachdPlace());
    }





    private void Update()
    {

        switch (state)
        {
            case FakePlayerState.Scouting:
                _timer += Time.deltaTime;
                if (_timer > delayBetweenLocations)
                {
                    GoScouting();
                    _timer = 0;
                }
                break;
            case FakePlayerState.Shooting:
                RunFromEnemy();
                attack.Attack();
                break;
            default:
                break;
        }   
    }


    private void RunFromEnemy()
    {
        Vector3 MoveBackwards = (transform.forward * -1) * 20;
        transform.LookAt(_target);       
        agent.destination = MoveBackwards;
    }


    private void GoScouting()
    {
        if (state != FakePlayerState.Pinged)
            agent.destination = WanderingLocation(transform.position, walkRadius);
    }


    private IEnumerator ReachdPlace()
    {
        yield return new WaitUntil(() => state == FakePlayerState.Pinged && CheckIfAgentReachedLocation());
        _collider.enabled = false;
        _collider.enabled = true;
        state = FakePlayerState.Scouting;
    }

    private bool CheckIfAgentReachedLocation()
    {
        if (_destination.x == transform.position.x && _destination.z == transform.position.z)
            return true;
        else
            return false;
    }


    public enum FakePlayerState
    {
        Scouting,
        Shooting,
        Pinged
    }


    private Vector3 WanderingLocation(Vector3 startPoint, float radius)
    {
        Vector3 dir = Random.insideUnitSphere * radius;
        dir += startPoint;
        NavMeshHit Hit;
        Vector3 FinalPos = Vector3.zero;
        if (NavMesh.SamplePosition(dir, out Hit, radius, 1))
            FinalPos = Hit.position;
        return FinalPos;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && state != FakePlayerState.Pinged)
        {
            state = FakePlayerState.Shooting;
            _target = other.gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _target = null;
            state = FakePlayerState.Scouting;
        }    
            
    }

}

