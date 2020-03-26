using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //skjuler cursor og låser den i midten af skærmen 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //input fra musen på x-asken
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //input fra musen på y-aksen

        //op og ned kig:
        xRotation -= mouseY;
        //stopper spileren for at kigge mere 180 grader op og ned så får øjne i nakken
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        //højre og venstre kig
        //playerbody rotere sammen med kameraet på x således at karakteren drejer når man kigger rundt
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
