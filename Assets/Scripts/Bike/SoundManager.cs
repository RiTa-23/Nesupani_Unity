using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //音声のリスト
    [SerializeField] AudioClip[] audioClips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlaySound(int index,float volume)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[index];
        //音量を設定
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource, audioClips[index].length);
    }

    
}
