using UnityEngine;

[System.Serializable]
public class OptionData
{
	public bool EnableAudio;
	public float MusicVolume;
	public float EffectVolume;

	public ResolutionOption Resolution;
	public bool FullScreen;

	public string Progress;

	public OptionData()
	{
		EnableAudio = FileUtility.DefaultEnableAudio;
		MusicVolume = FileUtility.DefaultMusicVolume;
		EffectVolume = FileUtility.DefaultEffectVolume;
		Resolution = FileUtility.DefaultResolution;
		FullScreen = FileUtility.DefaultFullScreen;
		Progress = "MainMenu";
	}

	public OptionData
		(
			bool enableAudio,
			float musicVolume,
			float effectVolume,
			ResolutionOption resolutionOption,
			bool fullScreen,
			string progress
		)
	{
		EnableAudio = enableAudio;
		MusicVolume = musicVolume;
		EffectVolume = effectVolume;
		Resolution = resolutionOption;
		FullScreen = fullScreen;
		Progress = progress;
	}

	public void SetResolutionDefault()
	{
		Resolution = FileUtility.DefaultResolution;
		FullScreen = FileUtility.DefaultFullScreen;
	}

	public void SetVolumeDefault()
	{
		EnableAudio = FileUtility.DefaultEnableAudio;
		MusicVolume = FileUtility.DefaultMusicVolume;
		EffectVolume = FileUtility.DefaultEffectVolume;
	}

	public void SetProgressDefault()
	{
		Progress = "MainMenu";
	}

	public void SetDefault()
	{
		EnableAudio = FileUtility.DefaultEnableAudio;
		MusicVolume = FileUtility.DefaultMusicVolume;
		EffectVolume = FileUtility.DefaultEffectVolume;
		Resolution = FileUtility.DefaultResolution;
		FullScreen = FileUtility.DefaultFullScreen;
		Progress = "MainMenu";
	}
}

[System.Serializable]
public enum ResolutionOption
{
	r1920x1080,
	r1366x768,
	r1280x720,
	r960x540,
	r640x360,
	r320x180,
}