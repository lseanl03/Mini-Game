using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothSpeed; 
    [SerializeField] private  Transform target;
    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target == null) return;
        Vector3 targetPosition = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

}
