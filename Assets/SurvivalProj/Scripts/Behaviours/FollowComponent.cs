using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float cameraMoveSpeed = 60F;

    private Vector3 offset;

    private void Start()
    {
        if (target == null)
        {
            enabled = false;
        }
        else
        {
            offset = transform.position - target.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, cameraMoveSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}