using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float tiempoEspera = 2f;

    private NavMeshAgent agent;
    private Animator animator;

    private int currentWaypoint = 0;
    private float contadorEspera = 0f;
    private bool esperando = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    private void Update()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        if (waypoints.Length == 0)
            return;

        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!esperando)
            {
                esperando = true;
                contadorEspera = 0f;
            }

            contadorEspera += Time.deltaTime;

            if (contadorEspera >= tiempoEspera)
            {
                esperando = false;

                currentWaypoint++;

                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }

                agent.SetDestination(waypoints[currentWaypoint].position);
            }
        }
    }
}