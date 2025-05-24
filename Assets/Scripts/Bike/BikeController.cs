using System.Diagnostics;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    float speed =7f;
    public float CurrentSpeed = 0f;
    public float tiltValue = 0f;

    float startTime;

    bool isGameOver = false;
    bool isGameStart = false;

    React_CallBack CallBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        CallBack = GameObject.Find("GameManager").GetComponent<React_CallBack>();
    }
    public void ChangeTiltValue(float value)
    {
        tiltValue = value;
        //傾きの値を制限
        if (tiltValue > 1.5)
        {
            tiltValue = 1.5f;
        }
        else if (tiltValue < -1.5)
        {
            tiltValue = -1.5f;
        }
    }

    public void AddSpeed(float value)
    {
        CurrentSpeed += value;
    }
    
    public void GameStart()
    {
        if(!isGameStart)
        {
            isGameStart = true;
            startTime = Time.time;
        }
    }

    public void GameOver()
    {
        //ゲームオーバー処理
        print("Game Over");
        //音を鳴らす
        SoundManager soundManager = gameObject.GetComponent<SoundManager>();
        soundManager.PlaySound(1, 1); // 1はゲームオーバー音のインデックス
        isGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        //転倒するか範囲外に出たらゲームオーバー
        if (!isGameOver && (Mathf.Abs(transform.position.x) > 6 || Mathf.Abs(transform.rotation.z) > 0.5))
        {
            GameOver();
        }
        
        if(!isGameOver&&isGameStart)
        {
            //スピードをコールバックで送信
            CallBack.ExecSpeedCallback(CurrentSpeed);
            //残りの距離をコールバックで送信
            CallBack.ExecDistanceCallback(transform.position.z);
            //経過時間をコールバックで送信
            CallBack.ExecTimeCallback(Time.time - startTime);

            //自動で加速・減速
            if (CurrentSpeed < speed)
            {
                CurrentSpeed += 1f * Time.deltaTime;
            }
            else if (CurrentSpeed > speed)
            {
                CurrentSpeed -= 2f * Time.deltaTime;
            }


            //ずっと前進
            transform.position += new Vector3(0, 0, CurrentSpeed) * Time.deltaTime;
            if (transform.position.x < 5 && transform.position.x > -5)
            {
                //傾きの値によって左右に移動
                transform.position += new Vector3(tiltValue * CurrentSpeed/3, 0, 0) * Time.deltaTime;

                //傾きの値によって傾ける
                transform.rotation = Quaternion.Euler(0, 0, -tiltValue * 30f);
            }
            else
            {
                //コース外に出ないようにする
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
}
