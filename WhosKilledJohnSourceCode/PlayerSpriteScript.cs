using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpriteScript : MonoBehaviour
{
    public SpriteRenderer character;

    private void Awake()
    {

        if (GameData.instance.returnSprite() != null)
        {
            character.sprite = GameData.instance.returnSprite();
        }

    }
}
