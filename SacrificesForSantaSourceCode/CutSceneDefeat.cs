using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneDefeat : MonoBehaviour
{
    public string[] dialogue = new string[10];

    public int x = 0;

    public Text texts;

    public Text message;

    public Animator anim;

	void Start ()
    {
        texts.text = dialogue[x];

        message.text = "Your score is " + GameData.Levels;

    }
	
	void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            x += 1;      
        }

        if (x < dialogue.Length)
        {
            texts.text = dialogue[x];
        }

        if (x == 1)
        {
            anim.Play("CutScene Defeat");
        }
        else if (x == 2)
        {
            anim.Play("SantaAppears-defeat");
        }
        else if (x == 5)
        {
            anim.Play("SantaLeaves - defeat");
        }
        else if (x == 6)
        {
            anim.Play("OneYearLater");
        }
        else if (x == 7)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
