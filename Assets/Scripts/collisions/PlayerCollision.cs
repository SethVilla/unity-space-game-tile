using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Player hit an asteroid! Game Paused.");
            
            // Pause the game
            Time.timeScale = 0.0f;
        }
    }
}

