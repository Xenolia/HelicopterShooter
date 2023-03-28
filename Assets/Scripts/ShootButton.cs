using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler,IPointerClickHandler
{
    [HideInInspector]
    public bool Pressed;
    public bool Clicked;

    // Use this for initialization
    void Start()
    {
        Clicked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
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