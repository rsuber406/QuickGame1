using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  [SerializeField]  private int trashCollected = 0;
    private int maxTrashInLevel = 16;
    [SerializeField] private TMP_Text trashCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AddTrash()
    {
        trashCollected = trashCollected + 1;
        UpdateUI();

    }
    void Update()
    {
        UpdateUI();
        
    }

    public void UpdateUI()
    {
        trashCountText.text = $"{trashCollected}/{maxTrashInLevel}";
        Debug.Log("Trash collected: " + trashCollected);
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
