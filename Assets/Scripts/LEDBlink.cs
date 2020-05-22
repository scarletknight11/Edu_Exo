using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino; //Library to get Arduino to communicate into unity

public class LEDBlink : MonoBehaviour {

    // Start is called before the first frame update
    void Start()
    {
        //get digital input singal from pin 12
        UduinoManager.Instance.pinMode(12, PinMode.Output);
        StartCoroutine(BlinkLoop());
    }

    // Update is called once per frame
    IEnumerator BlinkLoop()
    {
        //Have LED continously blink
        while (true) {
            //Increase bright LED output 
            UduinoManager.Instance.digitalWrite(12, State.HIGH);
            //delay LED frequency for a few seconds
            yield return new WaitForSeconds(0.5f);
            //Decrease bright LED output 
            UduinoManager.Instance.digitalWrite(12, State.LOW);
            //delay LED frequency for a few seconds
            yield return new WaitForSeconds(0.5f);
        }

    }
}
