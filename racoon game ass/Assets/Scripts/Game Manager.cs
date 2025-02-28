using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    [SerializeField] public GameObject player;
    [SerializeField] private LoadLevel loadLevel;
   

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        loadLevel.LoadLevelNumeric_ClearOld(0);
        CharacterController playerController = player.GetComponent<CharacterController>();
        playerController.enabled = false;
        player.transform.position = new Vector3(104, 4, 0);
        playerController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static GameManager GetInstance()
    {
        return instance;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
