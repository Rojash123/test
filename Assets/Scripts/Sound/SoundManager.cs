using UnityEngine;
using UnityEngine.UI;

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
            bgAudioSource.mute = value;
            sfxAudioSource.mute = value;
            PlayerPrefs.SetInt("sound", value ? 0 : 1);
        }
    }
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    public void HandeToggleChange(bool isSoundOn)
    {
        SoundManager.Instance.PlayUIClickSound();
        IsSoundMuted = !isSoundOn;
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
    public void PlayGameWin()
    {
        if (IsSoundMuted) return;
        sfxAudioSource.PlayOneShot(soundSO.GetSound(SoundType.RoundWin));
    }

}
