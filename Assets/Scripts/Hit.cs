using UnityEngine;

public class Hit : Subject
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the vehicles GameObject
        if (collision.gameObject.CompareTag("Vehicles"))
        {
            NotifyObserver(PlayerAction.ExitPanel_true);
        }

        else if(collision.gameObject.CompareTag("Pedistrains"))
        {
            NotifyObserver(PlayerAction.ExitPanel_true);
        }

        else
        {
            NotifyObserver(PlayerAction.ExitPanel_false);
        }
    }
}
