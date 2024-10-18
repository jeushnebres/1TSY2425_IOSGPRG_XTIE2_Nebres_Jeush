using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothSpeed = 0.3f; // The speed at which the camera follows the player
    public float offsetX = 0; // The offset of the camera from the player on the x-axis
    public float offsetZ = -10; // The offset of the camera from the player on the z-axis

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x + offsetX, target.position.y, transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}