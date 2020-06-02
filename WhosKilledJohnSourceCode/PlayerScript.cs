using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform player;

    private Vector3 move;

    private Camera camera_main;

    private Vector2 look_position;

    public Transform gun;

    public Transform gun_barrel;

    public float speed;

    public AudioSource gunShot;

    bool canShoot = true;

    public SpriteRenderer gunShotSprite;

    private void Start()
    {
        player = GetComponent<Transform>();

        camera_main = Camera.main;
    }

    private void Update()
    {
        Movement();

        if (gun.rotation.z <= 0)
        {
            gun.Rotate(0, 0, 0);
        }
        else
        {
            gun.Rotate(0, 180, 0);
        }

        //Debug.Log(gun.rotation.eulerAngles.z + " | Player Gun");

        if (Input.GetButtonDown("Fire1") && canShoot)
            Shoot();
    }

    private void Movement()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 mouse_pos = camera_main.ScreenToWorldPoint(Input.mousePosition);

        look_position = new Vector3(
            mouse_pos.x - player.position.x,
            mouse_pos.y - player.position.y
            );

        Vector3 pos = transform.position;

        move.Set(h, v, 0);

        move = move.normalized * speed * Time.deltaTime;

        //rb.MovePosition(pos + move);

        gun.up = look_position;
    }

    IEnumerator ShootAnimation()
    {
        gunShotSprite.enabled = true;

        yield return new WaitForSeconds(0.15f);

        gunShotSprite.enabled = false;        
    }

    private void Shoot()
    {
        StartCoroutine(ShootAnimation());

        gunShot.Play();

        Debug.Log(gun.rotation.eulerAngles.z);

        RaycastHit2D hit = Physics2D.Raycast(gun_barrel.position, look_position);

        GameObject obj = null;

        if (hit.collider != null)
        {
            obj = hit.transform.gameObject;

            if (obj.GetComponent<npcScript>() != null)
                Debug.Log("You hit = " + obj.GetComponent<npcScript>().role.ToString());

            if (obj.GetComponent<npcScript>() == null)
            {
                return;
            }

            if (obj.GetComponent<npcScript>().role == NPCrole.Murderer)
            {
                canShoot = false;

                GameManager.instance.Victory();
            }
            else
            {
                canShoot = false;

                GameManager.instance.Defeat();
            }
        }

    }
}
