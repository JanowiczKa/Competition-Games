using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CharacterSelector : MonoBehaviour
{
    public Sprite[] Characters;

    public string[] CharacterNames;

    public Image displayedCharacter;

    public Text CharacterName;

    public int currentCharacter;

    public GameData gameData;

    public AudioSource buttonPress;

    private void Start()
    {
        currentCharacter = 0;

        UpdateCharacter();
    }

    public void Forward()
    {
        currentCharacter++;

        if (currentCharacter >= Characters.Length)
            currentCharacter = 0;

        UpdateCharacter();

        buttonPress.Play();
    }

    public void Backwards()
    {
        currentCharacter--;

        if (currentCharacter < 0)
            currentCharacter = Characters.Length-1;

        UpdateCharacter();

        buttonPress.Play();
    }

    public void UpdateCharacter()
    {
        displayedCharacter.sprite = Characters[currentCharacter];
        CharacterName.text = CharacterNames[currentCharacter];

        GameData.instance.changeSprite(Characters[currentCharacter]);
    }

}
