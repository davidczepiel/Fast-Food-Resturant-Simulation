namespace UCM.IAV.Movimiento
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraControler : MonoBehaviour
    {
        //Velocidad de movimiento de la camara
        public float velocidad = 2;

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            transform.position = transform.position + (new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime));
            if (Input.GetKey(KeyCode.E))
            {
                transform.position = transform.position + (new Vector3(0, velocidad * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                transform.position = transform.position + (new Vector3(0, -velocidad * Time.deltaTime, 0));
            }
        }
    }
}