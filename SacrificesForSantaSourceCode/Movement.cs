using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;

    public Transform hands;

    Rigidbody2D rb;

    public Vector3 move;

    public float v;

    public float h;

    public Animator anim;

    public bool handsFull = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -20, 20);
        pos.y = Mathf.Clamp(pos.y, -20, 20);

        if (h > 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1.0f);
        else if (h < 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), 1.0f);

        bool walking = (Input.GetButton("Horizontal") || Input.GetButton("Vertical"));

        anim.SetBool("Walking", walking);

        move.Set(h, v, 0);

        move = move.normalized * speed * Time.deltaTime;

        rb.MovePosition(pos + move);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cookie" && handsFull == false)
        {
            collision.transform.SetParent(hands);

            collision.transform.localPosition = new Vector3(0, 0, 0);

            handsFull = true;

            if (collision.GetComponent<Animator>() != null)
            {
                collision.GetComponent<Animator>().Play("Scared");
            }
        }
    }
}
