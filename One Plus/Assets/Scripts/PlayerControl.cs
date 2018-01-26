using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private float speed;
    private bool hasKey;
    private Rigidbody2D rigidbody;
    private bool grounded;

    // Use this for initialization
    void Start()
    {
        speed = 3;
        hasKey = false;
        rigidbody = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Wrap();
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "spike")
        {
            //Destroy(this.gameObject);
            transform.position = new Vector3(-5f, -2f, 0);
        }
        if(collision.gameObject.tag == "key")
        {
            Destroy(collision.gameObject);
            hasKey = true;
        }
        if(collision.gameObject.tag == "Goal" && hasKey)
        {
            // Code to enter next level
            // SceneManager.LoadScene([Level here]);
        }
    }

    public bool IsGrounded()
    {
        if (this.rigidbody.velocity.y != 0)
        {
            grounded = false;
        }
        else
        {
            grounded = true;
        }
        return grounded;
    }

    void Move()
    {
        Vector2 move = rigidbody.velocity;
        float axisX = Input.GetAxis("Horizontal");

        move.x = axisX * speed;

        if(Input.GetButton("Jump") && IsGrounded())
        {
            move.y = 7;
        }
        rigidbody.velocity = move;
    }

    void Wrap()
    {
        if (this.gameObject.transform.position.y <= -12f)
        {
            transform.position = new Vector3(-5f, -2f, 0);
        }
    }
}