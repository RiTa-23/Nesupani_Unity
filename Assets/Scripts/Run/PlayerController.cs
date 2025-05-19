using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    float jumpForce = 5f;
    bool isGrounded = true;
    public bool isGameOver = false;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void SpeedUp()
    {
        speed += 0.1f;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            //前方向に自動で進む
            transform.Translate(transform.right * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
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
