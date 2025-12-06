using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource bgAudioSource, sfxAudioSource;
    [SerializeField] SoundSO soundSO;

    private bool isSoundMuted = false;
    public bool IsSoundMuted
    {
        get { return isSoundMuted; }
        set
        {
            isSoundMuted = value;
            PlayerPrefs.SetInt("sound", value ? 0 : 1);
        }
    }
    public override void Awake()
    {
        base.Awake();
        if (!PlayerPrefs.HasKey("sound"))
        {
            IsSoundMuted = false;
            return;
        }
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            IsSoundMuted = true;
        }
        else
        {
            IsSoundMuted = false;
        }
    }
    private void Start()
    {
        EnableBGmusic();
    }
    public void EnableBGmusic()
    {
        if (IsSoundMuted) return;
        Debug.Log("enabled");
        bgAudioSource.Play();
    }
    public void DisableBGmusic()
    {
        bgAudioSource.Stop();
    }
    public void PlayUIClickSound()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.UIClick));
    }
    public void PlayMatchedSound()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.Matched));
    }
    public void NotMatchedSound()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.NotMatched));
    }
    public void PlayComboSound()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.Combo));
    }
    public void PlayFlipCard()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.CardFlip));
    }
    public void PlayCardDistrbute()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.CardDistrbute));
    }
}
