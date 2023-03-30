using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;

    // Update is called once per frame
    
    void Update()
    {
        Pressed = true;
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                /*
                Debug.Log(PointerId + PointerOld.x + PointerOld.y);

                TouchDist = Input.touches[PointerId].position - PointerOld;
                PointerOld = Input.touches[PointerId].position;
                */
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld;
                 PointerOld = Input.mousePosition;
                //Debug.Log(PointerId + PointerOld.x +"  "+ PointerOld.y + "else");
            }
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
       // PointerId = eventData.pointerId;
      //  PointerOld = eventData.position;
     }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

}