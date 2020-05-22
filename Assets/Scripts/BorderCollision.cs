using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class BorderCollision : MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(12, PinMode.Output);

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
