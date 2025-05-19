using UnityEngine;

public class run_obstacles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
                float speed = playerController.speed;
                playerController.GameOver();

                //x軸負の方向に力を加える
                Vector3 direction = new Vector3(-1, 1, 0);
                collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 3, ForceMode.Impulse);
            }
            
        }
    }
}
