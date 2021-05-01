using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source; 

    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(soundEffects sound) {
        source.clip = sounds[(int) sound];
        source.Play(0);
    }
}


public enum soundEffects {
    croak,
    coin
}
