using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BikeController bikeController = other.GetComponent<BikeController>();
            if (bikeController != null)
            {
                print("SpeedUp");
                //音を鳴らす
                SoundManager soundManager = other.gameObject.GetComponent<SoundManager>();
                soundManager.PlaySound(2, 1); // 2はスピードアップ音のインデックス

                //スピードを上げる
                bikeController.AddSpeed(5f);
            }
        }
    }
}
