using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class run_obstacles : MonoBehaviour
{
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if(!playerController.isGameOver)
            {
                float speed =playerController.speed ;

                if (speed > 2f)
                {
                    //スピードを下げる
                    playerController.speed = 1f;
                    //x軸負の方向に力を加える
                    Vector3 direction = new Vector3(-1, 1, 0);
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 3, ForceMode.Impulse);
                    rb.AddForce(-direction  * speed, ForceMode.Impulse);

                }
            }
            
        }
    }
}
