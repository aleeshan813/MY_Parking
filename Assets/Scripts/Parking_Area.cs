using UnityEngine;

public class Parking_Area : MonoBehaviour
{
    [SerializeField] Material parkingAreaColor;

    // Start is called before the first frame update
    void Start()
    {
        Material parkingAreaMaterial = GetComponent<Material>();

        // Check the initial color and change it if needed
        CheckAndChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        // You can call CheckAndChangeColor() here if you want to continuously check and update color.
    }

    void CheckAndChangeColor()
    {
        Color currentColor = parkingAreaColor.color;

        if (currentColor == Color.green)
        {
            parkingAreaColor.color = Color.red;
        }
        else
        {
            parkingAreaColor.color = Color.red;
        }
    }
}
