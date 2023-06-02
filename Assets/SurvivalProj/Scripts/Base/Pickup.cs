using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Pickup : MonoBehaviour
{
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}