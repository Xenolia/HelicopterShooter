using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float speed;
    bool stepped;
    // Start is called before the first frame update
    void Start()
    {
        stepped = false;
       // iTween.MoveBy(gameObject, iTween.Hash("y", -2, "easeType", "easeInOutExpo", "loopType", "none", "delay", .1));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,  1 *speed* Time.deltaTime,0); //rotates 50 degrees per second around z axis

        if (gameObject.transform.eulerAngles.y <= 30 && !stepped && gameObject.transform.eulerAngles.y >= 20) {
            stepped = true;
            StepDown();
            
        }

    }

    void StepDown() {
         iTween.MoveBy(gameObject, iTween.Hash("y", -2.5f, "easeType", "easeInOutExpo", "loopType", "none", "delay", .1));
         stepped = false;

    }
}
