using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SteeringWeel : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    bool Wheelbeingheld = false;
    float WheelAngle = 0f;
    float LastWheelAngle = 0f;
    Vector2 center;

    [SerializeField] RectTransform Wheel;
    [SerializeField] float MaxSteerAngle = 200f;
    [SerializeField] float ReleaseSpeed = 300f;
    [SerializeField] float Output;

    // Update is called once per frame
    void Update()
    {
        if(!Wheelbeingheld && WheelAngle != 0f)
        {
            float DeltaAngle = ReleaseSpeed * Time.deltaTime;   
            if(Mathf.Abs(DeltaAngle) > Mathf.Abs(WheelAngle))
            {
                WheelAngle = 0f;
            }   

            else if(WheelAngle > 0f) 
            {
                WheelAngle -= DeltaAngle;
            }

            else
            {
                WheelAngle += DeltaAngle;
            }
        }
        Wheel.localEulerAngles = new Vector3(0,0, -WheelAngle);
        Output = WheelAngle / MaxSteerAngle;
    }

    public void OnPointerDown(PointerEventData data)
    {
        Wheelbeingheld = true;
        center = RectTransformUtility.WorldToScreenPoint(data.pressEventCamera, Wheel.position);
        LastWheelAngle = Vector2.Angle(Vector2.up, data.position - center);
    }
    public void OnDrag(PointerEventData data)
    {
        float NewAngle = Vector2.Angle(Vector2.up, data.position - center);
        if((data.position - center).sqrMagnitude >= 400)
        {
            if(data.position.x > center.x)
            {
                WheelAngle += NewAngle - LastWheelAngle;
            }
            else 
            {
                WheelAngle -= NewAngle - LastWheelAngle;
            }
        }
        WheelAngle = Mathf.Clamp(WheelAngle, -MaxSteerAngle, MaxSteerAngle);
        LastWheelAngle = NewAngle;
    }
    public void OnPointerUp(PointerEventData data)
    {
        OnDrag(data);
        Wheelbeingheld = false;
    }
}
