using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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
