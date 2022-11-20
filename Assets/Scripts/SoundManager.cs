using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    #region Singleton
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
                instance = new SoundManager();
            return instance;
        }
    }

    private SoundManager() { }
    #endregion
    public GameObject soundManager;

    private AudioSource ShootingSound;
    private AudioSource ReloadingSound;
    private AudioSource PlayerHurtSound;
    private AudioSource ZombieHurtSound;
    private AudioSource ZombieAttackSound;
    private AudioSource ZombieSound;
    private AudioSource RumbaMusic;

    public void Initialize()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").gameObject;
    }

    public void SecondInitialize()
    {
        AudioSource[] tabAudioSource = soundManager.GetComponents<AudioSource>();

        ShootingSound = tabAudioSource[0];
        ReloadingSound = tabAudioSource[1];
        PlayerHurtSound = tabAudioSource[2];
        ZombieHurtSound = tabAudioSource[3];
        ZombieAttackSound = tabAudioSource[4];
        ZombieSound = tabAudioSource[5];
        RumbaMusic = tabAudioSource[6];
    }

    public void PlayShootingSound()
    {
        ShootingSound.Play();
    }

    public void PlayReloadingSound()
    {
        ReloadingSound.Play();
    }

    public void PlayPlayerHurtSound()
    {
        PlayerHurtSound.Play();
    }

    public void PlayZombieHurtSound()
    {
        ZombieHurtSound.Play();
    }

    public void PlayZombieAttackSound()
    {
        ZombieAttackSound.Play();
    }

    public void PlayZombieSound()
    {
        ZombieSound.Play();
    }

    public void PlayRumbaMusic()
    {
        RumbaMusic.Play();
    }

    public void StopZombieSound()
    {
        ZombieSound.Stop();
    }
}
