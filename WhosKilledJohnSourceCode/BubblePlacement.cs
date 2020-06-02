using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblePlacement : MonoBehaviour
{
    public Transform speaker;

    public Transform speakerFinger;

    public Vector3 newPos;

    public Vector3 distToSpeaker;

    private void Start()
    {
        distToSpeaker = new Vector3(-1.4f, 1.4f, 0);

        newPos = speaker.position + distToSpeaker;

        transform.position = newPos;

        Debug.Log(speakerFinger.localEulerAngles.z + " + " + gameObject.name);
    }

    private void Update()
    {
        newPos = speaker.position + distToSpeaker;
        
        transform.position = newPos;
    }

}
