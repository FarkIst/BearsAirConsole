using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpjectilePickup : MonoBehaviour {

    public GameObject puffPrefab;

    private void Start()
    {
       // puffPrefab = Resources.Load("PuffSprite") as GameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddTrumpjectile(Random.Range(1, 3));
            GameObject go = Instantiate(puffPrefab, transform.position, transform.rotation);
         //   go.transform.parent = GameObject.Find("Props").transform;
            Destroy(gameObject);
        }
    }


}
