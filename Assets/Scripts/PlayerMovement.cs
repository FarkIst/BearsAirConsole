using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Range(0f, 20f)]
    public float movementSpeed;

    [Range(0f, 10f)]
    public float jumpValue;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public GameObject bombPrefab;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool _left;
    private bool _right;
    private bool isGrounded;
    
    

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (_left)
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            sr.flipX = false;
        }
        if (_right)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            sr.flipX = true;
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Right Collider" || other.gameObject.name == "Left Collider")
        {
            transform.position = new Vector2(transform.position.x / Mathf.Abs(transform.position.x) - transform.position.x, transform.position.y);
        }
    }

    public void SetLeft(bool left)
    {
        _left = left;
    }

    public void SetRight(bool rigth)
    {
        _right = rigth;
    }

    public void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(Vector2.up * jumpValue, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetTrigger("jump");
        }
        if (!isGrounded)
        {
            GameObject go = Instantiate(bombPrefab, groundCheck.transform.position, transform.rotation);
        }
    }

    public void SetStop()
    {
        _left = false;
        _right = false; 
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        
    }

    public void AddDamage()
    {
        anim.SetTrigger("dead");
    }

}
