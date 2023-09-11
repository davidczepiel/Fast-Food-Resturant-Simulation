using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField]
    float movementVelocity = 2;

    // Update is called once per frame
    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + (new Vector3(horizontal * movementVelocity * Time.deltaTime, 0, vertical * movementVelocity * Time.deltaTime));
        if (Input.GetKey(KeyCode.E))
            transform.position = transform.position + (new Vector3(0, movementVelocity * Time.deltaTime, 0));
        else if (Input.GetKey(KeyCode.Q))
            transform.position = transform.position + (new Vector3(0, -movementVelocity * Time.deltaTime, 0));
    }
}