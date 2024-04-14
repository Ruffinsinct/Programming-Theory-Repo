using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;    
    public float rotationSpeed = 5.0f;

    public Transform cameraTransform;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = moveVertical * cameraForward + moveHorizontal * cameraTransform.right;

        movement.Normalize();

        playerRb.velocity = movement * speed;

        float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;


        transform.Rotate(Vector3.up, rotation);

        RotateCameraWithPlayer(rotation);


    }
    
    void RotateCameraWithPlayer(float rotationAmount)
    {
        if (cameraTransform != null)
        {
            cameraTransform.Rotate(Vector3.right, rotationAmount);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }
    }

}
