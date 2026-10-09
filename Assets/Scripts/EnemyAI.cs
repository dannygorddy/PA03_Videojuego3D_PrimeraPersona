using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Patrulla")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float tiempoEspera = 2f;
    [SerializeField] private float velocidadPatrulla = 2.5f;

    [Header("Persecucion")]
    [SerializeField] private Transform player;
    [SerializeField] private float rangoDeteccion = 10f;
    [SerializeField] private float rangoPerdida = 14f;
    [SerializeField] private float velocidadPersecucion = 4f;

    private NavMeshAgent agent;
    private Animator animator;

    private int currentWaypoint = 0;
    private float contadorEspera = 0f;

    private bool esperando = false;
    private bool persiguiendo = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        agent.speed = velocidadPatrulla;

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    private void Update()
    {
        // Animacion
        if (animator != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        if (player == null)
            return;

        float distanciaJugador =
            Vector3.Distance(transform.position, player.position);

        // Detectar jugador
        if (!persiguiendo && distanciaJugador <= rangoDeteccion)
        {
            IniciarPersecucion();
        }

        // Perder jugador
        if (persiguiendo && distanciaJugador >= rangoPerdida)
        {
            TerminarPersecucion();
        }

        if (persiguiendo)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }
    }

    private void Patrullar()
    {
        if (waypoints.Length == 0)
            return;

        if (esperando)
        {
            contadorEspera += Time.deltaTime;

            if (contadorEspera >= tiempoEspera)
            {
                esperando = false;

                currentWaypoint++;

                if (currentWaypoint >= waypoints.Length)
                {
                    currentWaypoint = 0;
                }

                agent.SetDestination(
                    waypoints[currentWaypoint].position
                );
            }

            return;
        }

        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            esperando = true;
            contadorEspera = 0f;

            agent.ResetPath();
        }
    }

    private void IniciarPersecucion()
    {
        persiguiendo = true;
        esperando = false;

        agent.speed = velocidadPersecucion;
    }

    private void PerseguirJugador()
    {
        agent.SetDestination(player.position);
    }

    private void TerminarPersecucion()
    {
        persiguiendo = false;

        agent.speed = velocidadPatrulla;

        if (waypoints.Length > 0)
        {
            agent.SetDestination(
                waypoints[currentWaypoint].position
            );
        }
    }
}