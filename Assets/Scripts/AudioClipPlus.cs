using System;
using UnityEngine;

public class AudioClipPlus : MonoBehaviour
{
    public string StreamingAssetsFilePath;
    private AudioHandler AudioHandler;
    public AudioClip audioClip;

    protected void Awake()
    {
        var source = gameObject.AddComponent<AudioSource>();
        source.clip = audioClip;
        AudioHandler = new AudioHandler(source, StreamingAssetsFilePath);
    }

    public void Play()
    {
        AudioHandler.Play();
    }
}