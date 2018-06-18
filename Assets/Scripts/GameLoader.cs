using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

    public GameObject[] objectsToEnable;
	
    // Use this for initialization
	void Start () {
		foreach(GameObject go in objectsToEnable)
        {
            go.SetActive(false);
        }
        StartCoroutine(StartGame());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(10);
        foreach (GameObject go in objectsToEnable)
        {
            go.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
