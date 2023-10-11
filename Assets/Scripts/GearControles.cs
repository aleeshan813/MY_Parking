using UnityEngine;

public class GearControles : MonoBehaviour
{
    [SerializeField] ParkingBrake parkingBrake;
    [SerializeField] CarController carController;

    [SerializeField] AudioSource TireSource;
    [SerializeField] AudioSource DriveSourc;



    float brakePower = 50000;

    bool isDriving = false;
    bool isBraking = true;

    public void StartDriving()
    {
        isDriving = true;
        isBraking = false;
        ReleaseBrake();
        carController.enabled = true;
        TireSource.enabled = true;
        DriveSourc.enabled = true;
    }

   
   public void ApplyParkingBrake()
    {
        carController.enabled = false;
        TireSource.enabled = false;
        DriveSourc.enabled = false;

        isDriving = false;
        isBraking = true;
        parkingBrake.WheelFR.brakeTorque = brakePower;
        parkingBrake.WheelFL.brakeTorque = brakePower;
        parkingBrake.WheelBR.brakeTorque = brakePower;
        parkingBrake.WheelBL.brakeTorque = brakePower;
    }

    void ReleaseBrake()
    {
        parkingBrake.WheelFR.brakeTorque = 0;
        parkingBrake.WheelFL.brakeTorque = 0;
        parkingBrake.WheelBR.brakeTorque = 0;
        parkingBrake.WheelBL.brakeTorque = 0;
    }

    void Update()
    {
        if (isBraking)
        {
            ApplyParkingBrake();
        }

        if (isDriving)
        {
            ReleaseBrake();
        }
    }
}

[System.Serializable]

    public class ParkingBrake
    {
        public WheelCollider WheelFL;
        public WheelCollider WheelFR;
        public WheelCollider WheelBL;
        public WheelCollider WheelBR;

}
