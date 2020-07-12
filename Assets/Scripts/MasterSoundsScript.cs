using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MasterSoundsScript : MonoBehaviour
{
    //AudioSources
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource timerSfxSource;

    //AudioClips
    public AudioClip menuMusic;
    public AudioClip mainMusic;
    public AudioClip meetingEndMusic;

    public AudioClip buttonClic;
    public AudioClip newMessage;
    public AudioClip validateIdea;
    public AudioClip deleteIdea;
    public AudioClip meetingAboutToEnd;
    public AudioClip meetingEnd;
    public AudioClip goodNotation;
    public AudioClip badNotation;

    //AudioCLips lists + Index for AudioClips lists
    public List<AudioClip> Character1Blabla = new List<AudioClip>();
    public List<AudioClip> Character2Blabla = new List<AudioClip>();
    public List<AudioClip> Character3Blabla = new List<AudioClip>();
    public List<AudioClip> Character4Blabla = new List<AudioClip>();
    public List<AudioClip> Character5Blabla = new List<AudioClip>();
    public List<AudioClip> Character6Blabla = new List<AudioClip>();
    public List<AudioClip> Character7Blabla = new List<AudioClip>();
    private int randomIndex;

    //Snapshots
    public AudioMixerSnapshot MusicOn;
    public AudioMixerSnapshot MusicOff;

    //Singleton
    public static MasterSoundsScript instance;

    void Awake()
    {
        //***SINGLETON***
        instance = this;

        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void PlayMainlMusic()
    {
        musicSource.clip = mainMusic;
        musicSource.Play();
    }

    public void PlayMeetingEndMusic()
    {
        StartCoroutine("PlayMeetingEndMusicTransition");
    }

    public IEnumerator PlayMeetingEndMusicTransition()
    {
        MusicOff.TransitionTo(1f);
        yield return new WaitForSeconds(1f);
        musicSource.clip = meetingEndMusic;
        musicSource.Play();
        MusicOn.TransitionTo(1.5f);
        yield return null;
    }

    public void PlayButtonClic()
    {
        sfxSource.PlayOneShot(buttonClic);
    }

    public void PlayValidateIdea()
    {
        sfxSource.PlayOneShot(validateIdea);
    }

    public void PlayDeleteIdea()
    {
        sfxSource.PlayOneShot(deleteIdea);
    }

    public void PlayMeetingAboutToEnd()
    {
        timerSfxSource.clip = meetingAboutToEnd;
        timerSfxSource.Play();
    }

    public void PlayMeetingEnd()
    {
        timerSfxSource.Stop();
        sfxSource.PlayOneShot(meetingEnd);
    }

    public void PlayGoodNotation()
    {
        sfxSource.PlayOneShot(goodNotation);
    }

    public void PlayBadNotation()
    {
        sfxSource.PlayOneShot(badNotation);
    }

    public void PlayCharacter1Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character1Blabla.Count - 1);
        sfxSource.PlayOneShot(Character1Blabla[randomIndex]);
    }

    public void PlayCharacter2Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character2Blabla.Count - 1);
        sfxSource.PlayOneShot(Character2Blabla[randomIndex]);
    }

    public void PlayCharacter3Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character3Blabla.Count - 1);
        sfxSource.PlayOneShot(Character3Blabla[randomIndex]);
    }

    public void PlayCharacter4Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character4Blabla.Count - 1);
        sfxSource.PlayOneShot(Character4Blabla[randomIndex]);
    }

    public void PlayCharacter5Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character5Blabla.Count - 1);
        sfxSource.PlayOneShot(Character5Blabla[randomIndex]);
    }

    public void PlayCharacter6Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character6Blabla.Count - 1);
        sfxSource.PlayOneShot(Character6Blabla[randomIndex]);
    }

    public void PlayCharacter7Blabla()
    {
        sfxSource.PlayOneShot(newMessage);
        randomIndex = Random.Range(0, Character7Blabla.Count - 1);
        sfxSource.PlayOneShot(Character7Blabla[randomIndex]);
    }

}
