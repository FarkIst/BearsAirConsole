using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

    public GameObject[] objectsToEnable;

    void Start()
    {
        foreach (GameObject go in objectsToEnable)
        {
            go.SetActive(false);
        }
    }

    public void SetStart()
    {
        foreach (GameObject go in objectsToEnable)
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
        yield return new WaitForSeconds(5);
        foreach (GameObject go in objectsToEnable)
        {
            go.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
