using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieGeneration : MonoBehaviour
{

    public GameObject cookie;

    public GameObject Home;

    public float HomeRadius;

    public int Homes;

    public Vector2 WorldSize;

    public float cookies = 3;

    Vector2[] HomesArray;

    Vector2 pos;

    Collider2D[] neighbours;

    public int level;

    private void Start()
    {
        level = GameData.Levels;

        HomesArray = new Vector2[Homes];

        for (int i = level; i < HomesArray.Length; i++)
        {
            pos = RandomPosition(new Vector2(0, 0), WorldSize);

            float distance = Vector2.Distance(new Vector2(0,0), pos);

            neighbours = Physics2D.OverlapCircleAll(pos, HomeRadius);

            while ((distance < HomeRadius && distance > -HomeRadius) || (neighbours.Length > 0))
            {    
                pos = RandomPosition(new Vector2(0, 0), WorldSize);

                distance = Vector2.Distance(new Vector2(0, 0), pos);

                neighbours = Physics2D.OverlapCircleAll(pos, HomeRadius);

                Debug.Log(distance);

                Debug.Log(neighbours.Length);
            }

            HomesArray[i] = pos;

            for (int b = 0; b < cookies; b++)
            {
                pos = RandomPosition(HomesArray[i], new Vector2(5, 5));

                Instantiate(cookie, pos, Quaternion.identity);
            }

            Instantiate(Home, HomesArray[i], Quaternion.identity);
        }
    }

    private Vector2 RandomPosition(Vector2 centre, Vector2 WorldSize)
    {
        Vector2 position = centre + new Vector2(Random.Range(-WorldSize.x / 2, WorldSize.x / 2), Random.Range(-WorldSize.y / 2, WorldSize.y / 2));

        return position;
    }
}
