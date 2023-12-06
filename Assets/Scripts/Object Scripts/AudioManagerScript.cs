using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance {get; private set;}
    [SerializeField] private AudioClip explosionFX; // Assign through inspector
    [SerializeField] private AudioSource _audioSource; // Assign through inspector

    void Awake()
    {
    // Make sure there isn't another instance already
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
    // Instantiate the static game object instance
        Instance = this;
    // Make sure it stays alive
        DontDestroyOnLoad(gameObject);
    }

  /// Call from another script to play your clip
    public void PlayExplosionFX()
    {    
        _audioSource.PlayOneShot(explosionFX);
    }
}
