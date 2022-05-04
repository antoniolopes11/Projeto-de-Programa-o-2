using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    private Dictionary<GameObject, Transform> oldParents = new Dictionary<GameObject, Transform>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        oldParents.Add(other.gameObject, other.transform.parent);

        other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (oldParents.TryGetValue(other.gameObject, out Transform oldTransformParent))
        {
            other.transform.SetParent(oldTransformParent);
            oldParents.Remove(other.gameObject);
        }
        else
        {
            other.transform.SetParent(null);
        }
    }
}
