using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float speed =5f;
    public float tiltValue = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeTiltValue(float value)
    {
        tiltValue = value;
    }

    // Update is called once per frame
    void Update()
    {
        //ずっと前進
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        if (transform.position.x < 5 && transform.position.x > -5)
        {
            //傾きの値によって左右に移動
            transform.position += new Vector3(tiltValue * 5, 0, 0) * Time.deltaTime;

            //傾きの値によって傾ける
            transform.rotation = Quaternion.Euler(0, 0, -tiltValue * 30f);
        }
        else
        {
            //画面外に出たら反対側から出てくる
            if (transform.position.x > 5)
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            else if (transform.position.x < -5)
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
        }
    }
}
