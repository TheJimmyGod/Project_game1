using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float MoveInput;
    public float JumpForce;
    private bool IsGrounded;
    public Transform GroundPosition;
    public float CheckRadius;
    public LayerMask FigureGroundOut;
    private int JumpRange;
    public int JumpRangeValue;
    void Start()
    {
        JumpRange = JumpRangeValue;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(IsGrounded==true)
        {
            JumpRange = 2;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && JumpRange > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            JumpRange--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && JumpRange == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
        }
    }
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundPosition.position, CheckRadius, FigureGroundOut);

        MoveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
        if(facingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && MoveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
