using UnityEngine;

public class AIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static AIController instance;
    private GameObject player;
    
    void Start()
    {
        instance = this;
        player = GameManager.GetInstance().GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public static AIController GetAIController()
    {
        return instance;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
