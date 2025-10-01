using UnityEngine;

public class GameTileAsteroids : MonoBehaviour
{
    [Header("Asteroid Settings")]
    [SerializeField] private GameObject[] rockPrefabs; 
    [SerializeField] private int numberOfAsteroids = 5; // Re-enable with optimizations
    [SerializeField] private Camera mainCamera;

    private Vector3 areaSize; // size of the tile in world space

    void Start()
    {
        // Find the main camera if not assigned
        if (mainCamera == null)
            mainCamera = Camera.main;
            
        // Get tile size, to create the asteroids within the tile bounds
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            areaSize = rend.bounds.size;
        else
        {
            // we can check for a collider instead of a renderer, if no gametile is found
            Collider col = GetComponent<Collider>();
            areaSize = col != null ? col.bounds.size : Vector3.one;
        }

        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            GameObject prefab = rockPrefabs[Random.Range(0, rockPrefabs.Length)];

            // Create depth by spawning asteroids at different Y levels within the tile
            float yPosition;
            float scale;
            
            if (i < numberOfAsteroids / 2)
            {
                // Close asteroids (near center of tile)
                yPosition = Random.Range(-0.02f, 0.02f); // Very close to tile center (Y=0)
                scale = 0.02f; // Larger for close asteroids
            }
            else
            {
                // Far asteroids (near edges of tile)
                yPosition = Random.Range(-4.5f, 4.5f); // Near tile edges (tile height is 10, so ±5)
                scale = 0.02f; // Same scale for visibility
            }

            // Spawn asteroids within the game tile bounds (7.5 x 10 x 10)
            Vector3 localPos = new Vector3(
                Random.Range(-3.75f, 3.75f), // Within tile width (7.5/2 = 3.75)
                yPosition, // Different Y levels for depth
                Random.Range(-5f, 5f) // Within tile depth (10/2 = 5)
            );

            // Instantiate prefab using its original scale
            GameObject asteroid = Instantiate(prefab, transform.position + localPos, Random.rotation, transform);

            // Scale asteroids based on distance
            asteroid.transform.localScale = prefab.transform.localScale * scale;
        }
    }

    // Draw the tile bounds in the editor help with visuals
    void OnDrawGizmosSelected()
    {
        Renderer rend = GetComponent<Renderer>();
        Vector3 drawSize = rend != null ? rend.bounds.size : Vector3.one;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, drawSize);
    }
}
