using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour {

    public GameObject puffPrefab;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("AddPropDamage");
        }
        else if(other.gameObject.tag == "Platform")
        {
            GameObject go = Instantiate(puffPrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }


/*
    void AddLavaDamage(Vector2 center, Vector2 size)
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(center, size, 0);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.tag == "Player")
            {
                hitColliders[i].SendMessage("AddPropDamage");
            }
           if(hitColliders[i].gameObject.tag == "Platform")
            {
                Destroy(hitColliders[i]);
            }
            i++;
        }
    }
    */
}
