using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler,IPointerClickHandler
{
    public bool Pressed;
    public bool Clicked;
    PointerEventData fakeData;
    // Use this for initialization
    void Start()
    {
        Clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnPointerClick(fakeData);
            OnPointerDown(fakeData);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            OnPointerUp(fakeData);
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        fakeData = eventData;
       Clicked = true;
        Debug.Log("CLICKED");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
         Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        Pressed = false;
    }
}