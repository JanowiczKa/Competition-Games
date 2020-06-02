using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public string[] dialogue;

    public Text dialogueText;

    public int x = 0;

    public bool story = false;

    public Animator anim;

    private void Awake()
    {
        dialogueText.text = dialogue[x];
    }

    public void StartStory()
    {
        GameData.Levels = 1;

        anim.Play("StartStoryAnim");
       
        story = true;
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (story == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                x += 1;

                if (x >= dialogue.Length)
                {
                    StartGame();
                }
                else if (x < dialogue.Length)
                {
                    dialogueText.text = dialogue[x];
                }
                
            }

        }
    }
}
