using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BikeController bikeController = other.GetComponent<BikeController>();
            if (bikeController != null)
            {
                print("SpeedUp");
                bikeController.AddSpeed(5f);
            }
        }
    }
}
