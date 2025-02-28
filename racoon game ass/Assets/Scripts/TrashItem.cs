using UnityEngine;

public class TrashItem : MonoBehaviour
{
    private int trashAmount = 1;


   public void Collect()
   {
      ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
      
      scoreManager.AddTrash();
      
      Destroy(gameObject);
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Player"))
       {
           Collect();
       }
   }
}
