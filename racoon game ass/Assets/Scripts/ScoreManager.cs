using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int trashCollected = 0;
    private int maxTrashInLevel = 16;
    [SerializeField] private TMP_Text trashCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddTrash()
    {
        trashCollected++;

    }
    void Update()
    {
        UpdateUI();
        
    }

    private void UpdateUI()
    {
        trashCollected = 0;
        trashCountText.text = $"{trashCollected}/{maxTrashInLevel}";
    }

    public bool ALlTrashCollected()
    {
        return trashCollected >= maxTrashInLevel;
    }

    public void ResetTrash()
    {
        trashCollected = 0;

    }
}
