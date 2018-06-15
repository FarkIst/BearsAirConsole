using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public GameObject explodePrefab;
    public float explosionTime;
    
    

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToExplode());

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator WaitToExplode()
    {
        yield return new WaitForSeconds(explosionTime);
        GameObject go = Instantiate(explodePrefab, gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log("Coroutine finished");
        Destroy(gameObject);
        
    }


}
