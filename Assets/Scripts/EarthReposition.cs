using UnityEngine;
using System.Collections;

public class EarthReposition : MonoBehaviour
{
    [Header("Earth Position Settings")]
    public float targetZPosition = -10f;
    public float moveSpeed = 0.5f; // Units per second
    
    private Vector3 startPosition;
    private bool isMoving = false;
    
    void Start()
    {
        startPosition = transform.position;
        isMoving = true;
    }
    
    void Update()
    {
        if (isMoving)
        {
            // Move towards target Z position
            Vector3 currentPosition = transform.position;
            currentPosition.z = Mathf.MoveTowards(currentPosition.z, targetZPosition, moveSpeed * Time.deltaTime);
            transform.position = currentPosition;
            
            // Check if we've reached the target position
            if (Mathf.Approximately(currentPosition.z, targetZPosition))
            {
                isMoving = false;
                Destroy(gameObject);
            }
        }
    }
}
