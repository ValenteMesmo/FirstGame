using UnityEngine;

[RequireComponent(typeof(AudioClipPlus))]
public class EmitSoundOnCollision : MonoBehaviour
{
    private AudioClipPlus Audio;

    void Start()
    {
        Audio = GetComponent<AudioClipPlus>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
            Audio.Play();
    }
}
