using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public float size;

	void Awake ()
    {
        size = Random.Range(2.0f, 4.0f);

        size = Mathf.Round(size * 10) / 10;

        transform.localScale = new Vector3(size, size, size);
	}

}
