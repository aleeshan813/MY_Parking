using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] GameObject ExitMenu;
 
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the vehicles GameObject
        if (collision.gameObject.CompareTag("Vehicles"))
        {            
            ExitMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        else if(collision.gameObject.CompareTag("Pedistrains"))
        {
            ExitMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            ExitMenu.SetActive(false);
        }
    }
}
