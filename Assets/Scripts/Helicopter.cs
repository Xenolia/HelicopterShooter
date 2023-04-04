using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float speed;
    bool stepped;
    int stepCount=0;
    int maxStepCount;
    // Start is called before the first frame update
     
    void Start()
    {
        GameManager gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = speed-(gameManager.CurrentLevel/10f);
        maxStepCount = gameManager.Level[gameManager.CurrentLevel].GetComponent<FloorCount>().floorCount;
        stepped = false;
       // iTween.MoveBy(gameObject, iTween.Hash("y", -2, "easeType", "easeInOutExpo", "loopType", "none", "delay", .1));
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0,  1 *speed* Time.deltaTime,0); //rotates 50 degrees per second around z axis

        return;

        if (gameObject.transform.eulerAngles.y <= 30 && !stepped && gameObject.transform.eulerAngles.y >= 20) {
            stepped = true;
            StepDown();
            
        }

    }
   
   public void StepDown() {
        if (stepCount >= maxStepCount)
            return;

         iTween.MoveBy(gameObject, iTween.Hash("y", -2.5f, "easeType", "easeInOutExpo", "loopType", "none", "delay", .1));
         stepped = false;
        stepCount++;
    }
}
