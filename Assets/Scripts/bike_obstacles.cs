using UnityEditor.Callbacks;
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
                print("SpeedDown");
                float speed = bikeController.CurrentSpeed;

                // 速度を減少させる
                if (speed > 7)
                {
                    bikeController.AddSpeed(-10f);
                }
                else
                {
                    bikeController.AddSpeed(-(speed + 1));
                }

                // 物理的な反発を追加
                Vector3 forceDirection = other.transform.position - transform.position;
                rb.AddForce(forceDirection.normalized * speed * 5, ForceMode.Impulse);
            }
        }
    }
}
