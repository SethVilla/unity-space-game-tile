using UnityEngine;

public class EarthSpin : MonoBehaviour
{
    [Header("Earth Position Settings")]
    public float earthZPosition = -10f;
    
    void Start()
    {
        // Set the Earth's Z position to the specified value
        Vector3 currentPosition = transform.position;
        currentPosition.z = earthZPosition;
        transform.position = currentPosition;
    }
}
