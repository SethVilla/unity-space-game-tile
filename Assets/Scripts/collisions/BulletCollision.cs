using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float damage = .1f;

    void Start()
    {
        damage = 1f;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Bullet hit for " + damage + " damage.");
            collision.gameObject.GetComponent<AsteroidCollision>().TakeDamage(damage);

            // Destroy the bullet after hitting
            Destroy(gameObject); 
            
        }
    }
}