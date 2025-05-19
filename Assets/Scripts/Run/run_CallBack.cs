using UnityEngine;
using System.Runtime.InteropServices;

public class run_CallBack : MonoBehaviour
{
    //- 残りの距離
    //- 残り時間
    //- スピード

    [DllImport("__Internal")]
    private static extern void DistanceCallback(float distance);
    [DllImport("__Internal")]
    private static extern void TimeCallback(float time);
    [DllImport("__Internal")]
    private static extern void SpeedCallback(float speed);

    public void ExecDistanceCallback(float distance)
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
            DistanceCallback (distance);
#endif
    }
    public void ExecTimeCallback(float time)
    {
    # if UNITY_WEBGL == true && UNITY_EDITOR == false
            TimeCallback (time);
    # endif
    }
    public void ExecSpeedCallback(float speed)
    {
    # if UNITY_WEBGL == true && UNITY_EDITOR == false
            SpeedCallback (speed);
    # endif
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
