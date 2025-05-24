using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]GameObject[] obstacles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //オブジェクトを生成
        //x軸の間隔は最低でも5
        var placedX = new System.Collections.Generic.List<float>();
        for (int i = 0; i < 5; i++)
        {
            float x;
            bool valid;
            do
            {
                x = Random.Range(10f, 70f);
                valid = true;

                float interval = 5f;

                foreach (var px in placedX)
                {


                    if (Mathf.Abs(x - px) < interval)
                    {
                        valid = false;
                        break;
                    }
                }
            } while (!valid);

            placedX.Add(x);

            float y = -0.72f;
            float z = -13.2f;
            GameObject obj = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(x, y, z), Quaternion.Euler(0, 90, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
