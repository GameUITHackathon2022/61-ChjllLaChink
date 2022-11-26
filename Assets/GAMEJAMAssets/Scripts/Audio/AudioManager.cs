using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("------------------Sound tracks-------------------------")]
    public Sound[] soundtracks;
    [Header("------------------Sfx-------------------------")]
    public Sound[] sfx;
    //---------------------------------------------------------
    private Dictionary<string, Sound> dictSoundtracks;
    private Dictionary<string, Sound> dictSfx;
    private string currentSoundTrackKey;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in soundtracks)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = true;
        }
        foreach (Sound s in sfx)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = false;
        }


        dictSoundtracks = soundtracks.ToDictionary(sound => sound.key);
        dictSfx = sfx.ToDictionary(sound => sound.key);
    }

    public void SetVolume(float soundtrackVolume, float sfxVolume)
    {
        foreach (Sound s in soundtracks)
            s.volume = soundtrackVolume;
        foreach (Sound s in sfx)
            s.volume = sfxVolume;
    }

    public bool isPlayingSoundtrack()
    {
        var playingSoundtrack = soundtracks.ToList().Find(s => s.source.isPlaying);
        return playingSoundtrack != null;
    }

    public void PlayRandomSoundtrack()
    {
        if (!isPlayingSoundtrack())
        {
            var rnd = new System.Random();
            int index = rnd.Next(soundtracks.Count());
            soundtracks[index].source.Play();
        }
    }

    public void PlaySoundtrack(string key)
    {
        if (!isPlayingSoundtrack())
        {
            dictSoundtracks[key].source.Play();
            currentSoundTrackKey = key;
        }
    }

    public void PlaySfx(string key)
    {
        dictSfx[key].source.Play();
    }

    public void Stop(string key, SoundType type)
    {
        switch (type)
        {
            case SoundType.Soundtrack:
                dictSoundtracks[key].source.Stop();
                break;
            case SoundType.Sfx:
                dictSfx[key].source.Stop();
                break;
            default:
                break;
        }
    }

    public  void StopSoundTrack()
    {
        dictSoundtracks[currentSoundTrackKey].source.Stop();
    }

}
