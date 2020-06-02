using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator blackOutAnim;

    public AudioSource buttonPress;

    public void Play()
    {
        blackOutAnim.SetTrigger("FadeOut");

        StartCoroutine(FirstLevel());

        buttonPress.Play();
    }

    IEnumerator FirstLevel()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(1);
    }

}
