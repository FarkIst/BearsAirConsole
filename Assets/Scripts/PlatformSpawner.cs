using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public float position1x;
    public float position2x;
    public float positionY;
    public float speed;

    public GameObject[] objectsToSpawn;


    private Vector2 pos1;
    private Vector2 pos2;
    private GameObject m_Cam;
    private bool spawned;
    private float waitForSpawn;



	// Use this for initialization
	void Start () {
        m_Cam = GameObject.Find("Main Camera");
        StartCoroutine(Spawnable());
	}
	
	// Update is called once per frame
	void Update () {
        pos1 = new Vector2(position1x, m_Cam.transform.position.y + positionY);
        pos2 = new Vector2(position2x, m_Cam.transform.position.y + positionY);

        transform.position = Vector2.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1f)/2f);

        if (spawned == false)
        {
            spawned = true;
            Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], gameObject.transform.position, gameObject.transform.rotation);
            StartCoroutine(Spawnable());
        }
	}

    IEnumerator Spawnable()
    {
        waitForSpawn = Random.Range(2, 4);
        yield return new WaitForSeconds(waitForSpawn);
        spawned = false;
        Debug.Log("Coroutine finished");
    }
}
