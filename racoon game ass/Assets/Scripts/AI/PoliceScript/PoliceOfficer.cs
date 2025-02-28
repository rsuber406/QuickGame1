using System.Collections;
using UnityEngine;

public class PoliceOfficer : EnemyAI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Range(1, 8)] [SerializeField] private int animChangeSpeed;
    private Coroutine attackCo;

    // Update is called once per frame
    protected override void Update()
    {
        if (playerDetected)
        {
            float animSpeed = animationController.GetFloat("Speed");
            float velocity = agent.velocity.magnitude;
            animationController.SetFloat("Speed", Mathf.MoveTowards(animSpeed, velocity,animChangeSpeed * Time.deltaTime ));
            
        }

        base.Update();
    }


    protected override void AttackPlayer()
    {
        if (!isAttacking) return;
        if (Vector3.Distance(AIController.GetAIController().GetPlayer().transform.position, transform.position) <
            agent.stoppingDistance)
        {
          
            attackCo = StartCoroutine(CarryoutAttack());
        }
    }

    private IEnumerator CarryoutAttack()
    {
        isAttacking = true;
        animationController.SetTrigger("Attack");
        yield return new WaitForSeconds(2.5f);
        isAttacking = false;

    }
    
}
