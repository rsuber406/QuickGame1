using UnityEngine;

public class PoliceOfficer : EnemyAI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Range(1, 8)] [SerializeField] private int animChangeSpeed;
   

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
    
    
}
