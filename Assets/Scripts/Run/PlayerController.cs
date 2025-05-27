using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    float jumpForce = 5f;
    bool isGrounded = true;
    public bool isGameOver = false;
    bool isGameStart = false;
    Rigidbody rb;
    React_CallBack CallBack;
    float startTime;

    SoundManager soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CallBack = GameObject.Find("GameManager").GetComponent<React_CallBack>();
        soundManager = GetComponent<SoundManager>();
    }

    public void Jump()
    {
        if (isGrounded && !isGameOver && isGameStart)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            //音を鳴らす
            soundManager.PlaySound(1, 1); 
        }
    }
    public void SpeedUp()
    {
        if (speed < 5)
        {
            speed += 0.5f;
            soundManager.PlaySound(0, 1);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void GameStart()
    {
        if(!isGameStart)
        {
            isGameStart = true;
            startTime = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart&&Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }

        if (!isGameOver && isGameStart)
        {
            //スピードをコールバックで送信
            CallBack.ExecSpeedCallback(speed);
            //残りの距離をコールバックで送信
            CallBack.ExecDistanceCallback(transform.position.x);
            //経過時間をコールバックで送信
            CallBack.ExecTimeCallback(Time.time - startTime);

            //自動で減速
            if (speed > 1f)
            {
                speed -= 0.25f * Time.deltaTime;
            }
            else if (speed < 1f)
            {
                speed = 1f;
            }

            //前方向に自動で進む
            transform.Translate(transform.right * speed * Time.deltaTime);

            //debug用の入力

            if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                SpeedUp();
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }
}
