using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class EnemyAI : MonoBehaviour, AI_Interface
{
    [Header("AI Configuration")] [SerializeField]
    protected NavMeshAgent agent;

    [SerializeField] protected float FOV;

    [SerializeField] protected float roamingRange;
    [SerializeField] protected float waitTime;
    [SerializeField] private Transform headPos;
    [SerializeField] protected Animator animationController;
    [SerializeField] private bool CharacterAttacksPlayer;
    protected bool playerDetected = false;

    protected bool isWaitingAtLocation = false;

    private float fovAsDecimal;

    protected bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fovAsDecimal = (100f - FOV) / 100f;
    }

    // Update is called once per frame
   protected virtual void Update()
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
            Vector3 direction = (playePos - headPos.position).normalized;
            RaycastHit hit;
            int ignoreLayer = LayerMask.GetMask("Enemy");
            Debug.DrawRay(headPos.position, direction * 30f, Color.red);
            if (Physics.Raycast(headPos.position, direction, out hit, ignoreLayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    if (!isAttacking)
                    {
                        ChasePlayer();
                    }

                    if (Vector3.Distance(GameManager.GetInstance().GetPlayer().transform.position,
                            transform.position) < agent.stoppingDistance)
                    {
                        FacePlayer();
                        AttackPlayer();
                    }
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

    protected virtual void AttackPlayer()
    {
        
    }

    private void FacePlayer()
    {
        Vector3 direction = (AIController.GetAIController().GetPlayer().transform.position - transform.position).normalized;
        
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}