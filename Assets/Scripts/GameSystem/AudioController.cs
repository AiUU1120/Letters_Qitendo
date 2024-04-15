using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    private AudioSource audioSource;

	public bool EnableAudio;
    [Range(0f, 100f)]
	public float MusicVolume;
    [SerializeField,Range(0f,1f)]
    private float TrueMusicVolume;
    //[Range(0f,100f)]
	//public float EffectVolume;
    //[SerializeField,Range(0f,1f)]
    //private float TrueEffectVolume;


	private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }

    private void Update()
    {
        if(OptionController.Instance != null)
        {
			UpdateVolume();
		}

	}

    public void UpdateVolume()
    {
        EnableAudio = OptionController.Instance.data.EnableAudio;
        MusicVolume = OptionController.Instance.data.MusicVolume;
        //EffectVolume = SingletonGameSystem.Instance.optionSystem.data.EffectVolume;

        TrueMusicVolume = (MusicVolume / 100f);
        //TrueEffectVolume = (EffectVolume / 100f);

        audioSource.volume = (TrueMusicVolume >= 0f && TrueMusicVolume <= 1f) ? TrueMusicVolume : 0.5f;
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name">背景音乐文件名</param>
    /// <param name="isLoop">是否开启循环</param>
    public void PlayMusic(string name, bool isLoop = true)
    {
        if(EnableAudio)
        {
			audioSource.clip = GetAudioClip(name);
			audioSource.loop = isLoop;
			audioSource.Play();
		}
	}

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name">音效名</param>
  //  public void PlayeEffectSound(string name)
  //  {
  //      if(EnableAudio)
  //      {
		//	UpdateVolume();
  //          var volume = (TrueEffectVolume >= 0f && TrueEffectVolume <= 1f) ? TrueEffectVolume : 0.5f;
  //          audioSource.PlayOneShot(GetAudioClip(name), volume);
		//}
  //  }


    //暂停播放
    public void AudioPause()
    {
		audioSource.Pause();
    }

    //暂停后继续
    public void AudioContinue()
    {
        audioSource.UnPause();
    }

    //暂停播放
    public void AudioStop()
    {
        audioSource.Stop();
    }

    //切换音频
    public void AudioSwitch(string name, bool isLoop = false)
    {
        if(EnableAudio)
        {
			AudioClip clip = GetAudioClip(name);
			if (audioSource.isPlaying)
			{
				audioSource.Stop();
			}
			audioSource.clip = clip;
			audioSource.loop = isLoop;
			audioSource.Play();
		}
    }
	#region Utility
	public static AudioClip GetAudioClip(string name)
	{
		return Resources.Load<AudioClip>("Audio/" + name);
	}
	#endregion
}