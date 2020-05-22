using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using Uduino;

public class BarControl : MonoBehaviour {

    float speed = 5f;
    //Arduino Communication variable
    /// SerialPort sp;

    // Start is called before the first frame update
    void Start()
    {
        //Arduino COM port number
        // sp = new SerialPort("COM8", 9600);
        // sp.ReadTimeout = 10;
        // sp.Open();
        UduinoManager.Instance.pinMode(12, PinMode.Output);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        // if (sp.IsOpen)
        // {
        //try-catch statement prevents our entire game 
        //from stopping in case the serial read function does not work, 
        //because no data is being sent by the Arduino
        //    try {
        //read the by tes that are sent from the Arduino and store them locally
        //      int value = sp.ReadByte();
        //maps input into unity cordinate system
        //      float positionUnity = (10 - ((float)value / 10));
        //moves position of bar object through exoskeleton control. Updates game object’s x-position with the new value at every frame
        //     transform.position = new Vector3(positionUnity, transform.position.y, transform.position.z);
        //  }
        //catch statements will be activated and provide an error handling message in case the serial communication does not work
        //  catch (System.Exception e) {

        //  }
        //  }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            UduinoManager.Instance.digitalWrite(12, State.HIGH);
            StartCoroutine(WaitForIt(0.5f));
        }
    }

    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        UduinoManager.Instance.digitalWrite(12, State.LOW);
    }
}
