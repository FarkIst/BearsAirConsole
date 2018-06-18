using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [Range(0f, 20f)]
    public float movementSpeed;

    [Range(0f, 10f)]
    public float jumpValue;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public GameObject bombPrefab;
    public GameObject puffPrefab;
    public Transform bombSpawn;
    public Text uiText;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private int projectileCount;
    private bool _left;
    private bool _right;
    private bool isGrounded;
    
    

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        uiText = GameObject.Find(gameObject.name + "t").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        uiText.text = "Projectiles: " + projectileCount.ToString();


        if (_left)
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            sr.flipX = false;
            GetComponentInChildren<HairFab>().FlipHair(true);
            bombSpawn.localPosition = new Vector2(1f, 0f);
        }
        if (_right)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            sr.flipX = true;
            GetComponentInChildren<HairFab>().FlipHair(false);
            bombSpawn.localPosition = new Vector2(-1f, 0f);
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

    }

    public void Shoot()
    {
        if(projectileCount > 0)
        {
            GameObject go = Instantiate(bombPrefab, bombSpawn.transform.position, bombSpawn.transform.rotation);
            Rigidbody2D projectile = go.GetComponent<Rigidbody2D>();
            projectile.AddForce(bombSpawn.transform.localPosition * 500f);
            projectileCount = projectileCount - 1;
        }
        else
        {
            return;
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
        rb.AddForce(transform.localPosition * 10f);
        anim.SetTrigger("dead");
    }

    public void AddTrumpjectile(int proj)
    {
        projectileCount += proj;
    }

    public void AddPropDamage()
    {
        Instantiate(puffPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        GameObject.Find("GameController").GetComponent<GControllerScript>().GetDeadPlayer(gameObject.name);
    }

}
