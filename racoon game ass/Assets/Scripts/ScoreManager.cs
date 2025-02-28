using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int trashCollected = 0;
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
        trashCountText.text = trashCollected.ToString();
    }

    public void ResetTrash()
    {
        trashCollected = 0;

    }
}
