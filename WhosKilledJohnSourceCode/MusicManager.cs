using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource Music;

    public bool MusicOn = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (MusicOn == true)
        {
            Music.volume = 0.05f;
        }
        else
        {
            Music.volume = 0.0f;
        }
    }

    public void MuteMusic()
    {
        MusicOn = GameData.instance.MuteMusic();
    }

    private void Update()
    {
        if (MusicOn == true)
        {
            Music.volume = 0.05f;
        }
        else
        {
            Music.volume = 0.0f;
        }
    }
}
