using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    private Rigidbody2D myRigidbody2D = null;

    private Animator myAnimator = null;

    private bool jump = false;

    [SerializeField]
    private float jumpForce = 400f;

    [SerializeField]
    private Transform[] checkPoints = null;

    private Collider2D[] results = new Collider2D[1];

    [SerializeField]
    private LayerMask groundLayerMask;

    private bool isGrounded = false;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        myRigidbody2D.velocity = new Vector2(horizontalInput * speed, myRigidbody2D.velocity.y);

        if (IsFacingBackwards(horizontalInput))
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        myAnimator.SetBool("Grounded", isGrounded);
        myAnimator.SetFloat("HorizontalSpeed", Mathf.Abs(myRigidbody2D.velocity.x));
        myAnimator.SetFloat("VerticalSpeed", myRigidbody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();

        if (jump && isGrounded)
        {
            Jump();
        }
        jump = false;
    }

    private bool CheckGround()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (Physics2D.OverlapPointNonAlloc(checkPoints[i].position, results, groundLayerMask) > 0 && Mathf.Abs(myRigidbody2D.velocity.y) < 0.01f)
            {
                return true;
            }
        }
        return false;
    }
    private void Jump()
    {
        myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, 0f);
        myRigidbody2D.AddForce(Vector2.up * jumpForce);
    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private bool IsFacingBackwards(float horizontalInput)
    {
        return transform.right.x < 0f && horizontalInput > 0f || transform.right.x > 0f && horizontalInput < 0f;
    }

    public void Die()
    {
        myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
    }
}
