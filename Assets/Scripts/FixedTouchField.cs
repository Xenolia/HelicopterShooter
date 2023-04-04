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
    bool startWork = false;

    private void Start()
    {
        startWork = true;
    }
    bool IsMouseOverGameWindow { get { return !(0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y); } }

    void Update()
    {
        if (!startWork)
        {
            TouchDist = new Vector2(0, 0); 
            return; 
        }
      //  Debug.Log(Input.mousePosition.x);

        if(Input.mousePosition.x>=Screen.width)
        {

        }
        if (!IsMouseOverGameWindow)
        {
            TouchDist = new Vector2(0, 0);
            return;
        }
            

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
                float a = Input.mousePosition.x;
              //  Mathf.Clamp(a,0,100);
                TouchDist = new Vector2(a, Input.mousePosition.y) - PointerOld;
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