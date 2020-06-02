using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text textUI;

    public float points = 0;

    public float TotalScore = 15;

    public Animator anim;

    public float levels;


    void Start()
    {
        levels = GameData.Levels;

        textUI = GetComponentInChildren<Text>();

        textUI.text = points + " / " + (TotalScore + (levels * 5));
    }

    public void AddPoints(float additionalPoints)
    {
        points = additionalPoints;

        textUI.text = points + " / " + (TotalScore + (levels * 5));

        if (points > (TotalScore + (levels * 5)))
        {
            GameData.Levels += 1;

            SceneManager.LoadScene("CutScene - Victory");
        }
    }
}
