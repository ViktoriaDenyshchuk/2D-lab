using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.OnNotCollect();
        }
    }
}
   