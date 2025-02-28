using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, AI_Interface
{
    [Header("AI Configuration")] [SerializeField]
    protected NavMeshAgent agent;

    [SerializeField] protected float FOV;

    [SerializeField] protected float roamingRange;
    [SerializeField] protected float waitTime;
    [SerializeField] private Transform headPos;

    protected bool playerDetected = false;

    protected bool isWaitingAtLocation = false;

    private float fovAsDecimal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fovAsDecimal = (100f - FOV) / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected && !CanSeePlayer())
        {
            // Roam logic
        }
        else
        {
            // do not roam
        }

        // roam logic
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.isTrigger) return;

        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        if (other.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    private IEnumerator FollowTargetAndWait()
    {
        isWaitingAtLocation = true;
        yield return new WaitForSeconds(waitTime);
        isWaitingAtLocation = false;
    }


    public void PositionToAlertAI(Vector3 position)
    {
        agent.SetDestination(position);
        StartCoroutine(FollowTargetAndWait());
    }

    public virtual bool CanSeePlayer()
    {
        float dotProduct = Vector3.Dot(transform.forward,
            (GameManager.GetInstance().GetPlayer().transform.position - transform.position).normalized);

        if (dotProduct > fovAsDecimal)
        {
            Debug.Log(dotProduct);
            Vector3 playePos = GameManager.GetInstance().GetPlayer().transform.position;
            Vector3 direction = (playePos - transform.position).normalized;
            RaycastHit hit;
            int ignoreLayer = LayerMask.GetMask("Enemy");
            if (Physics.Raycast(headPos.position, direction, out hit, ~ignoreLayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    ChasePlayer();
                    return true;
                }
            }
        }

        return false;
    }

    protected void ChasePlayer()
    {
        // perform any necessary action here
        agent.SetDestination(GameManager.GetInstance().GetPlayer().transform.position);
    }
}