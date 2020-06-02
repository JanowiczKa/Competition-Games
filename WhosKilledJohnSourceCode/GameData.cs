using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public static Sprite headSprite;

    public static int SpriteINT;

    public static bool MusicMuted;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void changeSprite(Sprite newSprite)
    {
        headSprite = newSprite;
    }

    public bool MuteMusic()
    {
        MusicMuted = !MusicMuted;

        return MusicMuted;
    }

    public Sprite returnSprite()
    {
        return headSprite;
    }

    public int returnSpriteINT()
    {
        return SpriteINT;
    }

}
