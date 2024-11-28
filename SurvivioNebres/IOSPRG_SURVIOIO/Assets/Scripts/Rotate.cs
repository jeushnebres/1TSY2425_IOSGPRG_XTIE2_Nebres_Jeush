using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Joystick joystick;

    void Update()
    {
   
        Vector3 moveVector = new Vector3(joystick.Horizontal, joystick.Vertical, 0);

     
        if (moveVector.magnitude > 0)
        {
            
            float angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;

           
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        
            transform.rotation = rotation;
        }
    }
}