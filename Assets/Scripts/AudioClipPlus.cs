using System;
using UnityEngine;

public class AudioClipPlus : MonoBehaviour
{
    public AudioClip Audio;
    public string StreamingAssetsFilePath;

    private AudioSource AudioSource;

#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaClass unityActivityClass;
    private AndroidJavaObject activityObj;
    private AndroidJavaObject soundObj;
    private int soundPoolAudioId;

    void Start()
    {
        if (string.IsNullOrEmpty(StreamingAssetsFilePath) == false)
        {
            unityActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activityObj = unityActivityClass.GetStatic<AndroidJavaObject>("currentActivity");
            soundObj = new AndroidJavaObject("com.catsknead.androidsoundfix.AudioCenter", 1, activityObj, activityObj);
            soundPoolAudioId = soundObj.Call<int>("loadSound", new object[] { StreamingAssetsFilePath });
        }
        else
        {
            AudioSource = gameObject.AddComponent<AudioSource>();
            AudioSource.clip = Audio;
        }
    }

    public void Play()
    {
        if (string.IsNullOrEmpty(StreamingAssetsFilePath) == false)
        {
            try
            {
                soundObj.Call("playSound", new object[] { soundPoolAudioId });
            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
            }
        }
        else
            AudioSource.Play();
    }
#else

    void Start()
    {
        AudioSource = gameObject.AddComponent<AudioSource>();
        AudioSource.clip = Audio;
    }

    public void Play()
    {
        AudioSource.Play();
    }

#endif
}