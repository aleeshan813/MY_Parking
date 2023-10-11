using TMPro;
using UnityEngine;

public class SpeedOmeter : MonoBehaviour

{
    public Rigidbody target;
    [SerializeField] float MaxSpeed = 0.0f; // The maximum speed of the target

    [SerializeField] float Max_speed_Angle;
    [SerializeField] float Min_speed_Angle;

    [Header("UI")]
    public TextMeshProUGUI speedLabel; // The label that display's the speed
    [SerializeField] RectTransform needleTransform; // The arrow in the speedometer

    float speed = 0.0f;


    private void Update()
    {
        //3.6f to convert in kilometers
        // The speed must be clamped by the car controller

        speed = target.velocity.magnitude * 3.6f;

        if (speedLabel != null)
        {
            speedLabel.text = ((int)speed) + "Km/h";
        }   
        if (needleTransform != null )
        {
            needleTransform.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(Min_speed_Angle, Max_speed_Angle, speed / MaxSpeed));
        }
    }  
}
