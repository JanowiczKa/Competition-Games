using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifices : MonoBehaviour
{
    public float points = 0;

    public float amount = 0;

    public Score scoreBoard;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cookie")
        {
            float pointsWorth = collision.GetComponent<Cookie>().size;

            collision.GetComponentInParent<Movement>().handsFull = false;

            points += pointsWorth;

            amount += 1;

            scoreBoard.AddPoints(points);

            Destroy(collision.gameObject);  
        }
    }
}