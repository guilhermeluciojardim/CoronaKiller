using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float speed = 5f;
    private float strafeSpeed = 2f;
    private float turnSpeed = 100f;
    private float horizontalInput;
    private float forwardInput;
    private float lookX;
    private float lookY;

    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCamera();

    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, lookX * Time.deltaTime * turnSpeed);

        lookX = Input.GetAxis("Mouse X");
        lookY = Input.GetAxis("Mouse Y");
        if (Input.GetKey (KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
        }
    }

    void StartCamera()
    {

    }
}
