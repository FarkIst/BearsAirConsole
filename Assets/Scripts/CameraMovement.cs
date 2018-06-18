using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed;
    public float delay = 7f;
    private bool delayed = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(Delay());
	}
	
	// Update is called once per frame
	void Update () {
        if(delayed)
        transform.Translate((Vector3.up * (Time.deltaTime * speed)), Space.World);
	}

    public void StartDelay()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        delayed = true;
    }

}
