using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionHandler : MonoBehaviour {

    public GameObject puffPrefab;
    public bool destroyed;
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
        if (coll.gameObject.tag == "Platform" && !coll.gameObject.GetComponent<PlatformCollisionHandler>().destroyed)
        {
            destroyed = true;
            Instantiate(puffPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            
       
            //  coll.gameObject.GetComponent<PlatformCollisionHandler>().CollisionHandler(this.gameObject, coll.gameObject);
            
 //           gl.ReplacePlatform(transform.position);
        }
    }

  /*  public void CollisionHandler(GameObject A, GameObject B)
    {
        Instantiate(puffPrefab, B.transform.position, B.transform.rotation);
        if (Physics.CheckSphere(A.transform.position, 1))
        {
            Debug.Log("already there");
            Destroy(B);
        }
        else
        {
            GameObject platform = Instantiate(A, A.transform);
        }
    }
    */
}
