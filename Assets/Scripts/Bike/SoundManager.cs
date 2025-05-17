using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //音声のリスト
    [SerializeField] AudioClip[] audioClips;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlaySound(int index)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[index];
        audioSource.Play();
        Destroy(audioSource, audioClips[index].length);
    }

    
}
