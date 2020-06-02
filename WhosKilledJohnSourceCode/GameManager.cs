using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Scene Manager")]

    public static GameManager instance;

    public Animator blackOutAnim;

    public Animator VictoryButtons;

    public Animator DefeatButtons;

    public int nextLevelIndex;

    [Header("Current Scene")]

    public Slider timer;

    public float maxTime;

    private float currTime;

    public bool finished;

    private Vector3[] characterPositions;

    private Transform[] NPCs;

    private int rand;

    public List<int> Used;

    public AudioSource buttonPress;

    public AudioSource defeatSound;

    public AudioSource victorySound;

    private void Awake()
    {
        timer.maxValue = maxTime;
        timer.value = maxTime;

        instance = this;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("NPC");

        characterPositions = new Vector3[objects.Length];

        NPCs = new Transform[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            characterPositions[i] = objects[i].transform.position;

            NPCs[i] = objects[i].transform;
        }

        MixPositions();
    }

    private void Update()
    {
        if (timer.value == timer.minValue)
        {
            Defeat();
        }

        if (!finished)
        {
            timer.value -= Time.deltaTime;
        }

    }

    private void MixPositions()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            rand = Random.Range(0, NPCs.Length);

            while (Used.Contains(rand))
            {
                rand = Random.Range(0, NPCs.Length);
            }

            NPCs[i].position = characterPositions[rand];

            Used.Add(rand);
        }
    }

    IEnumerator Appear(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        VictoryButtons.SetTrigger("Appear");
        DefeatButtons.SetTrigger("Appear");
    }

    IEnumerator Menu()
    {
        VictoryButtons.SetTrigger("Disappear");
        DefeatButtons.SetTrigger("Disappear");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(0);
    }

    IEnumerator NextLevel()
    {
        VictoryButtons.SetTrigger("Disappear");
        DefeatButtons.SetTrigger("Disappear");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(nextLevelIndex);
    }

    public void FadeOut()
    {
        blackOutAnim.SetTrigger("FadeOut");
    }

    public void LoadNextLevel()
    {
        buttonPress.Play();

        StartCoroutine(NextLevel());
    }

    public void LoadMenu()
    {
        buttonPress.Play();

        StartCoroutine(Menu());
    }

    public void Victory()
    {
        finished = true;

        victorySound.Play();

        FadeOut();

        DefeatButtons.gameObject.SetActive(false);

        StartCoroutine(Appear(0.9f));

        Debug.Log("Victory");
    }

    public void Defeat()
    {
        finished = true;

        defeatSound.Play();

        FadeOut();

        VictoryButtons.gameObject.SetActive(false);

        StartCoroutine(Appear(0.9f));

        Debug.Log("Defeat");
    }
}
