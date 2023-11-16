using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("triggered");
        if (other.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
        }
    }
}
