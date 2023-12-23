using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // ����ʵ��

    [SerializeField] AudioClip footstepSound;
    [SerializeField] AudioClip backgroundMusicSound;

    private AudioSource backgroundMusicSource;
    private AudioSource footstepAudioSource;

    private bool isBackgroundMusicPlaying = false;
    private bool isFootstepSoundPlaying = false;

    private void Awake()
    {  
        // ��������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���������������ڳ����л�ʱ��������
        }

        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        footstepAudioSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicSource.clip = backgroundMusicSound;
        footstepAudioSource.clip = footstepSound;
    }

    void Start()
    {
       
        PlayBackgroundMusic();
       
    }

    private void Update()
    {
        PlayerMovement player = PlayerMovement.instance;
        if (player != null)
        {
            // ��������Ƿ��ƶ������Ż�ֹͣ�Ų�����
            if (player.GetIfPlayerMoving())
            {
                PlayFootstepSound();
            }
            else
            {
                StopFootstepSound();
            }
        }
    }
    public void PlayFootstepSound()
    {
        if (!isFootstepSoundPlaying)
        {
            footstepAudioSource.Play();
            isFootstepSoundPlaying = true;
        }
    }

    public void StopFootstepSound()
    {
        if (isFootstepSoundPlaying)
        {
            footstepAudioSource.Stop();
            isFootstepSoundPlaying = false;
        }
    }

    public void PlayBackgroundMusic()
    {
        if (!isBackgroundMusicPlaying)
        {
            backgroundMusicSource.Play();
            isBackgroundMusicPlaying = true;
        }
    }

    public void StopBackgroundMusic()
    {
        if (isBackgroundMusicPlaying)
        {
            backgroundMusicSource.Stop();
            isBackgroundMusicPlaying = false;
        }
    }

    public bool IsBackgroundMusicPlaying()
    {
        return isBackgroundMusicPlaying;
    }

    public bool IsFootstepSoundPlaying()
    {
        return isFootstepSoundPlaying;
    }
}
