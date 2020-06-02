using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public string[] dialogue = new string[10];

    public int x = 0;

    public Text texts;

    public Animator anim;

	void Start ()
    {
        texts.text = dialogue[x];
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
            anim.Play("CutSceneVictory");
        }
        else if (x == 2)
        {
            anim.Play("SantaAppears");
        }
        else if (x == 5)
        {
            anim.Play("Santaleaves");
        }
        else if (x == 8)
        {
            anim.Play("OneYearLater");
        }
        else if (x == 9)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
