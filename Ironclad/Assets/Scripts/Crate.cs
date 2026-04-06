using UnityEngine;

public class Crate : MonoBehaviour
{
    [Header("Settings")]
    public int creditValue = 25; // credits awarded on destruction

    void OnTriggerEnter2D(Collider2D other)
    {
        // Only destroy if hit by a bullet
        if (other.CompareTag("Bullet"))
        {
            // Award credits to GameManager
            GameManager.Instance.AddCredits(creditValue);
            Debug.Log("Crate destroyed! +" + creditValue + " SC");

            // Destroy the crate
            Destroy(gameObject);
        }
    }
}