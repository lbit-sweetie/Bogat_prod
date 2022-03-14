using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] private float changePositionTime = 5f;
    [SerializeField] private float moveDistance = 10f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveEnemy), changePositionTime, changePositionTime);
    }

    private Vector3 RandomNavSphere(float distance) // —оздание рандомной точки, к которой направитс€ моб
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, distance, -1);

        return hit.position;
    }

    private void MoveEnemy()
    {
        navMeshAgent.SetDestination(RandomNavSphere(moveDistance));
    }
}
