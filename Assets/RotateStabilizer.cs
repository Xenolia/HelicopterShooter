using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStabilizer : MonoBehaviour
{
    private void LateUpdate()
    {
        var asd = transform.localEulerAngles;
        float clampedY=asd.y;
        //   clampedY = Mathf.Clamp(asd.y,-35f,+40f);

        while (clampedY > 180)
        {
            //subtract 360 from transform.eulerAngles.y so it is definitely negative. 
            clampedY -= 360;
        }
        if (clampedY<=-40)
        {
            clampedY = -40;
        }
        if (clampedY >= 45)
        {
            clampedY = 45;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, clampedY, 0f);
         
    }
}
