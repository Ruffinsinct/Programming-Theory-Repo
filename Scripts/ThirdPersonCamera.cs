using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;

    public float height = 2.0f;
    public float distance = 5.0f;
    public float smoothSpeed = 0.125f;
    public float roationDamping = 3.0f;

    public Vector3 offset;



 
    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        Vector3 desiredPosition = player.position - player.forward * distance + Vector3.up * height;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        Quaternion desiredRotation = Quaternion.LookRotation(player.position - transform.position, player.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * roationDamping);


    }
}
