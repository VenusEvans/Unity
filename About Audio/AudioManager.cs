using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;
    public AudioMixer audioMixer;

    //public AudioClip attackAudio; //背景音乐
    //public AudioClip jumpAudio; //跳跃声音
    public AudioClip[] allAudio; //数组存放所有声音

    AudioSource attackSource; //AudioSource可以理解为音乐播放器 有了他声音才会播放
    AudioSource jumpSource;
    AudioSource collectionSource;
    AudioSource hitSource;
    AudioSource gameoverSource;
    AudioSource winSource;

    void Awake()
    {
        audioManager = this;
        //DontDestroyOnLoad(gameObject); //在进入到新场景的时候不会销毁当前的游戏物体

        attackSource = gameObject.AddComponent<AudioSource>();
        jumpSource = gameObject.AddComponent<AudioSource>();
        collectionSource=gameObject.AddComponent<AudioSource>();
        hitSource = gameObject.AddComponent<AudioSource>();
        gameoverSource = gameObject.AddComponent<AudioSource>();
        winSource = gameObject.AddComponent<AudioSource>();
    }
    /*静态方法直接调用*/
    public static void PlayattackAudio() //播放攻击
    {
        audioManager.attackSource.playOnAwake = false;
        //audioManager.attackSource.clip = audioManager.attackAudio;
        audioManager.attackSource.clip = audioManager.allAudio[0]; //0是攻击声音
        audioManager.attackSource.Play();
    }

    public static void PlayJumpAudio() //播放跳跃
    {
        audioManager.jumpSource.playOnAwake = false;
        //audioManager.jumpSource.clip = audioManager.jumpAudio;
        audioManager.jumpSource.clip = audioManager.allAudio[1]; //1是跳跃声音
        audioManager.jumpSource.Play();
    }

    public static void PlayCollectionAudio() //播放吃果实
    {
        audioManager.collectionSource.playOnAwake = false;
        audioManager.collectionSource.clip = audioManager.allAudio[2]; //2是吃果实声音
        audioManager.collectionSource.Play();
    }

    public static void PlayHitAudio() //播放受伤
    {
        audioManager.hitSource.playOnAwake = false;
        audioManager.hitSource.clip = audioManager.allAudio[3]; //3是受伤音效
        audioManager.hitSource.Play();
    }

    public static void PlayGameOverAudio() //播放游戏结束
    {
        audioManager.gameoverSource.playOnAwake = false;
        audioManager.gameoverSource.clip = audioManager.allAudio[4]; //4是游戏结束声音
        audioManager.gameoverSource.Play();
        //audioManager.mainSource.enabled = false;
    }

    public static void PlayWinAudio() //任务完成
    {
        audioManager.winSource.playOnAwake = false;
        audioManager.winSource.clip = audioManager.allAudio[5]; //5是任务完成
        audioManager.winSource.Play();
    }

    public void SliderVolume(float value) //通过滑动条来控制声音（AudioMixer）
    {
        audioMixer.SetFloat("MainValue", value);
    }
}
