using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throttle : MonoBehaviour
{
    float throttle;
    float moderation = 0.5f;
    float decrease = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        throttle +=Input.GetAxis("Vertical")*moderation;
            throttle-= decrease; // Automatic deceleration
            throttle = Mathf.Clamp(throttle,0,10);
            print (throttle);
           
    }
}
