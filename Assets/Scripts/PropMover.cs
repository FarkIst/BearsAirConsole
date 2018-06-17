using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMover : MonoBehaviour {

    public float movementRange;
    public float speed;

    private Rigidbody2D rb;

    private Vector2 pos1;
    private Vector2 pos2;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        pos1 = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
        pos2 = new Vector2(movementRange, gameObject.transform.localPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector2.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1f) / 2f);
        
        if (transform.localPosition.x >= pos1.x - 0.3f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        if (transform.localPosition.x <= pos2.x + 0.3f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collided With Player!!");
            other.gameObject.GetComponent<PlayerMovement>().AddPropDamage();
        }
    }
}
