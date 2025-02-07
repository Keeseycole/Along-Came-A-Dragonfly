using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioData> sfxList;

    [SerializeField] public List<MusicData> musicList;
    [SerializeField] AudioSource musicPlayer;
    [SerializeField] AudioSource sfxPlayer;

    [SerializeField] float fadeDuration;

    float OriginalMusicVol;

    Dictionary<AudioID,AudioData> sfxLookup;

    public MusicData currentMusic;
    public static AudioManager i { get; private set; }

    private void Awake()
    {
        OriginalMusicVol = musicPlayer.volume;
        Debug.Log("MusicPlayer", musicPlayer.gameObject);
        i = this;
    }

    private void Start()
    {
        

       sfxLookup = sfxList.ToDictionary(x => x.audioid);
    }
    public void PlayMusic(MusicData clip, bool loop = true, bool fade = false)
    {
        //Debug.Log($"clip playing {clip}\n {loop} " );
        if(clip == null || clip == currentMusic) 
        {

          return;
        }
        currentMusic = clip;

        StartCoroutine(PlayMusicAsync(clip, loop, fade));
        

      
    }

    public void PlaySfx(AudioClip clip, bool pauseMusic = false)
    {
        if (clip == null)
        {
            return;
        }

        if(pauseMusic == true)
        {
            musicPlayer.Pause();
          //  StartCoroutine(UnPause(clip.length));
        }

        sfxPlayer.PlayOneShot(clip);
    }

    public void PlaySfx(AudioID audioID, bool pauseMusic = false)
    {
        if (sfxLookup.ContainsKey(audioID)) return;

        var audiodata = sfxLookup[audioID];
        PlaySfx(audiodata.clip);
    }

    public void MuteMusic()
    {

        Debug.Log("Music Off");
        musicPlayer.mute = true;

    }

    IEnumerator PlayMusicAsync(MusicData clip, bool loop, bool fade) 
    {
       
        if (fade)
       {
           Debug.Log($"clip playing {clip}\n {loop}");
          yield return musicPlayer.DOFade(0, fadeDuration).WaitForCompletion();
          Debug.Log($"Dofade finish");
        }

        if (musicList.Contains(clip) == false)
        {
            musicList.Add(clip);
        }
      
        if(clip.intro!= null)
        {
            musicPlayer.clip = clip.intro;
            musicPlayer.loop = false;
            musicPlayer.Play();
            yield return musicPlayer.DOFade(1, fadeDuration).WaitForCompletion();
            yield return new WaitForSeconds(clip.intro.length - 1);

            musicPlayer.clip = clip.loop;
            musicPlayer.loop = loop;
            musicPlayer.Play();
        } else
        {
          
            musicPlayer.clip = clip.loop;
            musicPlayer.loop = loop;
            musicPlayer.Play();

            yield return musicPlayer.DOFade(1, fadeDuration).WaitForCompletion();
          
        }
    
       
    }

    public void UnMute()
    {
        Debug.Log("Music On");
        musicPlayer.mute = false;
  
    }
}

public enum AudioID { hit, levelup}


[System.Serializable]
    public class AudioData
{
    public AudioID audioid;
    public AudioClip clip;
}


[System.Serializable]

public class MusicData
{   
    public AudioClip intro;
    public AudioClip loop;


}
