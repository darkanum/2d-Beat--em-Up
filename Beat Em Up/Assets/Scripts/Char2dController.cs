using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2dController : MonoBehaviour
{
    Animator animator;
    public float runSpeed = 5;
    public float jumpSpeed = 10;
    float yOffset = 1;
    float yPos;
    SpriteRenderer m_spriteRenderer;
    Rigidbody2D m_rigidBody;
    bool canJump = true;

    [SerializeField]
    float speed;
    // Use this for initialization
    void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody2D>();
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            m_rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, m_rigidBody.velocity.y);
            m_spriteRenderer.flipX = Input.GetAxis("Horizontal") > 0 ? false :
                (Input.GetAxis("Horizontal") < 0 ? true : m_spriteRenderer.flipX);
        }

        animator.SetFloat("speed", Mathf.Abs( m_rigidBody.velocity.x));
        animator.SetFloat("ySpeed", m_rigidBody.velocity.y);
        speed = m_rigidBody.velocity.y;

        if (Input.GetButtonDown("Fire1"))
        {
            Punch();
        }
    }

    void Punch()
    {
        if (animator.GetBool("punch") == false)
            animator.SetBool("punch", true);
        else
            animator.SetBool("combo", true);
        //animator.SetBool("punch", true);
        m_rigidBody.AddForce(m_spriteRenderer.flipX? Vector2.left * 200 : Vector2.right *200);
    }

    void EndPunch()
    {
        animator.SetBool("punch", false);
        animator.SetBool("combo", false);
    }

    void Jump()
    {
        canJump = false;
        yPos = transform.position.y;
        m_rigidBody.AddForce(new Vector2(0.0f, jumpSpeed));
        animator.SetBool("jumping", true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
            animator.SetBool("jumping", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = false;
        }
    }
}
