using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class run_obstacles : MonoBehaviour
{
    Rigidbody rb;
    //既に衝突したか
    bool isCollided = false;
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
            if(!playerController.isGameOver&& !isCollided)
            {
                float speed =playerController.speed ;

                if (speed > 2f)
                {
                    isCollided = true;
                    //スピードを下げる
                    playerController.speed = 1f;
                    //x軸負の方向に力を加える
                    Vector3 direction = new Vector3(-1, 1, 0);
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * 3, ForceMode.Impulse);
                    rb.AddForce(-direction * speed, ForceMode.Impulse);
                    //音を鳴らす
                    SoundManager soundManager = collision.gameObject.GetComponent<SoundManager>();
                    if (soundManager != null)
                    {
                        soundManager.PlaySound(2, 1); // 0は衝突音のインデックス
                    }

                }
            }
            
        }
    }
}
