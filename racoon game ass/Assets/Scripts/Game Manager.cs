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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
