using UnityEngine;

public class CarController : MonoBehaviour
{

    Rigidbody PlayerRB;
    Transform m_Transform;

    public WheelColliders colliders;
    public WheelMesh wheelmeshs;
    public WheelParticles wheelparticles;
    [SerializeField] GameObject[] BrakeLight;
    [SerializeField] Material BrakeMaterial;
    [SerializeField] Material Brake_off;


    [SerializeField] float gasInput;
    [SerializeField] float steeringInupt;
    [SerializeField] float motorPower;

    [SerializeField] float brakeInput;
    [SerializeField] float brakePower;
    [SerializeField] float slipAngle;

    [SerializeField] AudioSource MotorSound;
    [SerializeField] AudioSource BrakeSound;
    [SerializeField] AudioSource CarHorn;

    float Speed;

    // Particle System and Sound variables
    bool isBraked = false;

    [SerializeField] AnimationCurve steeringCarve;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = gameObject.GetComponent<Rigidbody>();
        m_Transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Speed = PlayerRB.velocity.magnitude;


        CheckInput();
        ApplySteering();
        ApplyBrake();

        ApplyMotor();
        ApplyWheelsPosition();

        if (isBraked)
        {
            PlayBrakeSound();
            ApplyBrakeParticles();
        }
        else
        {
            PlayMotorSound();
            StopBrakeParticles();
        }

    }

    private void ApplyWheelsPosition()
    {
        UpdateWheels(colliders.FRWheel, wheelmeshs.FRWheel);
        UpdateWheels(colliders.FLWheel, wheelmeshs.FLWheel);
        UpdateWheels(colliders.RRWheel, wheelmeshs.RRWheel);
        UpdateWheels(colliders.RLWheel, wheelmeshs.RLWheel);
    }

    private void UpdateWheels(WheelCollider collider, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;

        collider.GetWorldPose(out position, out quat);

        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;
    }

    //Movement Direction
    void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInupt = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            brakeInput = 1;
            gasInput = 0;
            isBraked = true;
        }
        else
        {
            brakeInput = 0;
            isBraked = false;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayCarHorn();
        }
    }

   void ApplyBrake()
{
    colliders.FRWheel.brakeTorque = brakeInput * brakePower * 0.7f;
    colliders.FLWheel.brakeTorque = brakeInput * brakePower * 0.7f;
    colliders.RRWheel.brakeTorque = brakeInput * brakePower * 0.3f;
    colliders.RLWheel.brakeTorque = brakeInput * brakePower * 0.3f;

    foreach (GameObject brakeLight in BrakeLight)
    {
        // Get the Renderer component of each BrakeLight GameObject
        Renderer brakeLightRenderer = brakeLight.GetComponent<Renderer>();

        if (brakeInput > 0)
        {
            // Apply the BrakeMaterial when brakes are applied
            brakeLightRenderer.material = BrakeMaterial;
        }
        else
        {
            // Apply the Brake_off material when brakes are released
            brakeLightRenderer.material = Brake_off;
        }
    }
}



    //The turning of the Front Wheels

    void ApplySteering()
    {
        float steeringAngle = steeringInupt * steeringCarve.Evaluate(Speed);
        colliders.FRWheel.steerAngle = steeringAngle;
        colliders.FLWheel.steerAngle = steeringAngle;
    }

    // Motor acclertion
    void ApplyMotor()
    {
        colliders.RRWheel.motorTorque = motorPower * gasInput;
        colliders.RLWheel.motorTorque = motorPower * gasInput;
    }

    // ParticleSystem of tires
    void ApplyBrakeParticles()
    {
        if (isBraked)
        {
            // Enable the particle system for both rear wheels
            if (wheelparticles.RLWheel != null)
            {
                if (!wheelparticles.RLWheel.isPlaying)
                    wheelparticles.RLWheel.Play();
            }

            if (wheelparticles.RRWheel != null)
            {
                if (!wheelparticles.RRWheel.isPlaying)
                    wheelparticles.RRWheel.Play();
            }
        }
    }

 // Stop the particle system for both rear wheels
    void StopBrakeParticles()
    {
       
        if (wheelparticles.RLWheel != null)
        {
            if (wheelparticles.RLWheel.isPlaying)
                wheelparticles.RLWheel.Stop();
        }

        if (wheelparticles.RRWheel != null)
        {
            if (wheelparticles.RRWheel.isPlaying)
                wheelparticles.RRWheel.Stop();
        }
    }

    // Playing Sound Effects
    void PlayBrakeSound()
    {
        if (!BrakeSound.isPlaying)
        {
            BrakeSound.Play();
            MotorSound.Stop();
        }
    }

    void PlayMotorSound()
    {
        if (!MotorSound.isPlaying)
        {
            MotorSound.Play();
            BrakeSound.Stop();
        }
    }

    void PlayCarHorn()
    {
        CarHorn.Play();
    }
}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider FRWheel;
    public WheelCollider FLWheel;
    public WheelCollider RRWheel;
    public WheelCollider RLWheel;
}

[System.Serializable]
public class WheelMesh
{
    public MeshRenderer FRWheel;
    public MeshRenderer FLWheel;
    public MeshRenderer RRWheel;
    public MeshRenderer RLWheel;
}

[System.Serializable]
public class WheelParticles
{
 
    public ParticleSystem RRWheel;
    public ParticleSystem RLWheel;
}
