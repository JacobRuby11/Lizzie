using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStopper : MonoBehaviour
{
    public List<GameObject> objectsToIgnore;

    void OnCollisionEnter(Collision collision)
    {
        if (objectsToIgnore.Contains(collision.gameObject))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
        }
    }
}
