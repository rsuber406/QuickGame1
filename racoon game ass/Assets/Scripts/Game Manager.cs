using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMovementScript playerScript;
    

    [SerializeField] public GameObject player;
    
   

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
