using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgmSource == null) return;
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        if (bgmSource == null) return;
        bgmSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }
}
