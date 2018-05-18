using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Range(0f, 20f)]
    public float movementSpeed;

    [Range(0f, 10f)]
    public float jumpValue;


    private bool _left;
   // private bool _jump;
    private bool _right;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (_left)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed,0);
        }
        if (_right)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0);
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpValue);
    }

    public void SetStop()
    {
        _left = false;
        _right = false;
        
    }
}
