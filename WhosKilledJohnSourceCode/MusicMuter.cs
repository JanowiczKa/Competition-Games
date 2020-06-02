using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMuter : MonoBehaviour
{
    public void MuteMusicInMenu()
    {
        MusicManager.instance.MuteMusic();
    }
}
