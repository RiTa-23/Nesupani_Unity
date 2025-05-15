using UnityEngine;

public class BikeController : MonoBehaviour
{
    float speed = 10f;
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tiltValue = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            tiltValue = 1f;
        }

        //ずっと前進
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        //傾きの値によって左右に移動
        transform.position += new Vector3(tiltValue*5, 0, 0) * Time.deltaTime;

        //傾きの値によって傾ける
        transform.rotation = Quaternion.Euler(0, 0, -tiltValue * 30f);
    }
}
