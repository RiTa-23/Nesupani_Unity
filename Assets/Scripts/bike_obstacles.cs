using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class bike_obstacles : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BikeController bikeController = other.gameObject.GetComponent<BikeController>();
            if (bikeController != null)
            {
                float speed = bikeController.CurrentSpeed;
                if(speed>3)
                {
                    bikeController.AddSpeed(-(speed + 1));
                    
                    //物理的な反発を追加
                    Vector3 forceDirection = other.transform.position - transform.position;
                    rb.AddForce(forceDirection.normalized * speed * 3, ForceMode.Impulse);
                }

            }
        }
    }
}
