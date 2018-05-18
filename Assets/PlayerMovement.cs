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

    private Rigidbody2D rb;

    private bool _left;
    private bool _right;
    private bool isGrounded;
    
    

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
	}
	
	// Update is called once per frame
	void Update () {

        if (_left)
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        if (_right)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
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

}
