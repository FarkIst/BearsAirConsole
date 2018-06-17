using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionHandler : MonoBehaviour {

    public GameObject puffPrefab;
//    private GameLogic gl;


	// Use this for initialization
	void Start () {
      //  gl = GameObject.Find("GameLogic").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {

            Instantiate(puffPrefab, coll.gameObject.transform.position, coll.gameObject.transform.rotation);
            Destroy(this.gameObject);
            
 //           gl.ReplacePlatform(transform.position);
        }
    }


}
