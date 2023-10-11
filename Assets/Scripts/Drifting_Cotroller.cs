using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Drifting_Cotroller : MonoBehaviour
{

    [SerializeField] Rigidbody Player_rb;

    bool isDirfting = false;

    float speed = 0;
    float driftAngle = 0;
    float driftFactor;

    float minimumSpeed = 5;
    float minimumAngle = 10;
    float driftingDelay = 0.2f;

    IEnumerator stopDrifthingCorutine = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageDrift();
    }

    void ManageDrift()
    {
        speed = Player_rb.velocity.magnitude;
        driftAngle = Vector3.Angle(Player_rb.transform.forward, (Player_rb.velocity + Player_rb.transform.forward).normalized);

        if (driftAngle > 120)
        {
            driftAngle = 0;
        }
        if (driftAngle >= minimumAngle && speed > minimumSpeed)
        {
            if(!isDirfting)
            {
                startDrifting();
            }
        }
        else
        {
            if(isDirfting)
            {
                stopDrifting();
            }
        }
    }

    async void startDrifting()
    {
        if (!isDirfting)
        {
            await Task.Delay(Mathf.RoundToInt(1000 * driftingDelay));
            driftFactor = 1;
        }

        isDirfting = true;
    }

    void stopDrifting()
    {
        stopDrifthingCorutine = stopingDrift();
        StartCoroutine(stopDrifthingCorutine);
    } 
    IEnumerator stopingDrift()
    {
        yield return new WaitForSeconds(driftingDelay * 4f);
        isDirfting = false;
    }
}
