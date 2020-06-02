using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{

    public NPCrole role;

    public Transform finger;

    public Transform target;

    public SpriteRenderer fingerImg;

    public SpriteRenderer headImg;

    public Vector3 originalPos;

    public float travelRadius = 0.35f;

    public float speed = 0.15f;

    public Vector3 newPos;

    Quaternion targetRotation;

    private void Start()
    {
        PointToTarget();

        originalPos = transform.position;

        newPos = transform.position;
    }

    public void ChangeAppearance(Sprite newFinger, Sprite newHead)
    {
        fingerImg.sprite = newFinger;

        headImg.sprite = newHead;
    }

    void PointToTarget()
    {

        Vector3 point_position = new Vector3(
            transform.position.x - target.position.x, 
            transform.position.y - target.position.y);

        finger.up = -point_position;

        //Debug.Log(finger.rotation.eulerAngles.z + " | NPCscript");

        if (finger.rotation.z <= 180.0f && finger.rotation.z > 0.0f)
        {
            Vector3 new_rotation = new Vector3(finger.rotation.x, 180, finger.rotation.z);

            finger.Rotate(new_rotation);
        }
        
    }


    private Vector3 GetNewPosition()
    {
        Vector3 destination = new Vector3(
            Random.Range(originalPos.x + -travelRadius, originalPos.x + travelRadius),
            Random.Range(originalPos.y + -travelRadius, originalPos.y + travelRadius),
            0);

        return destination;
    }

    private void Update()
    {        
        Vector3 direction = newPos - transform.position;
        float distance_this_frame = speed * Time.deltaTime;

        if (direction.magnitude <= distance_this_frame)
        {
            newPos = GetNewPosition();
        }

        transform.Translate(direction.normalized * distance_this_frame, Space.World);

        PointToTarget();
    }

}

public enum NPCrole { Murderer, Detective, Civilian };