using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;    
    public float rotationSpeed = 5.0f;

    public Transform cameraTransform;

    private Rigidbody playerRb;

    private float horizontalRotation = 0f;

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

    
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

    

        playerRb.velocity = transform.forward * movement.z * speed;

        float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;


        transform.Rotate(Vector3.up, rotation);

        horizontalRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -90f, 90f);

        cameraTransform.localEulerAngles = new Vector3(horizontalRotation, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }
    }

}
