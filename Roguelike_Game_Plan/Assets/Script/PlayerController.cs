using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public int health = 6;
    public float JumpForce;
    public Transform GroundPosition;
    public LayerMask FigureGroundOut;
    public float CheckRadius;
    public int JumpRangeValue;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float MoveInput;
    public bool IsGrounded;
    private int JumpRange;
    private Animator animator;
    private GameMaster gm;
    
    public int GetPower
    {
        get; set;
    }
    public int GetScore
    {
        get; set;
    }
    void Start()
    {
        JumpRange = JumpRangeValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.Checkpoints;
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("jump");
        }
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

    public void GetDamage(int Damage)
    {
        for (int i = 0; i < 30; i++)
        {
            transform.Translate(Vector2.up * 0.01f);
        }
        GetPower += 2;
        health -= Damage;
    }
}
