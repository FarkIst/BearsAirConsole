using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairFab : MonoBehaviour {

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {

        sr = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void FlipHair(bool flip)
    {
        if (flip) sr.flipX = true;
        else sr.flipX = false;
    }
}
