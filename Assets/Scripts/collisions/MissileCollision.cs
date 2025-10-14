using UnityEngine;

public class MissileCollision : MonoBehaviour
{
    public float damage = 10f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Missile hit for " + damage + " damage.");
            collision.gameObject.GetComponent<AsteroidCollision>().TakeDamage(damage);
            
            // Destroy the missile after hitting
            Destroy(gameObject);
        }
    }
}

