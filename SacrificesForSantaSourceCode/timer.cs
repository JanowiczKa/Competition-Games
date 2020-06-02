using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Slider sliderHealth;

    public bool countDown = false;

    public int levels;

    public Text message;

    void Start()
    {

        levels = GameData.Levels;

        sliderHealth = GetComponent<Slider>();

        sliderHealth.maxValue = (40.0f);

        sliderHealth.value = sliderHealth.maxValue;

        countDown = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal"))
        {
            countDown = true;
        }

        if (countDown == true)
        {
            sliderHealth.value -= 1.0f * Time.deltaTime;

            message.enabled = false;
        }

        if (sliderHealth.value <= sliderHealth.minValue)
        {
            SceneManager.LoadScene("CutScene - Defeat");
        }
        


    }

}
