using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public Sprite[] Heads;

    public Sprite[] Fingers;

    public npcScript[] NPCs;

    public List<int> Used;

    public int rand;

    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("NPC");

        NPCs = new npcScript[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            NPCs[i] = objects[i].GetComponent<npcScript>();
        }

        ApplyMakeUp();

        Used.Add(GameData.instance.returnSpriteINT());
    }

    private void ApplyMakeUp()
    {

        for (int i = 0; i < NPCs.Length; i++)
        {
            rand = Random.Range(0, Heads.Length);

            while (Used.Contains(rand)) 
            {
                rand = Random.Range(0, Heads.Length);
            }

            NPCs[i].ChangeAppearance(Fingers[rand], Heads[rand]);

            Used.Add(rand);
        }

    }
}
