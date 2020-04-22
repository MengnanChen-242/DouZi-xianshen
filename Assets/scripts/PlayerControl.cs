using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float MoveForce = 400f;
    public float MaxSpeed = 5f;
    public float jumpForce = 500f;

    [HideInInspector]
    public bool jump = false;
    private Transform groundCheck;
    private Rigidbody2D heroBody;
    [HideInInspector]
    public bool faceRight = true;
    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
    }


    void FixedUpdate()
    {
        //获取水平方向输入
        float input = Input.GetAxis("Horizontal");
        if(input * heroBody.velocity.x < MaxSpeed)
        {
            heroBody.AddForce(Vector2.right * input * MoveForce);
        }
        if(Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x)
                * MaxSpeed, heroBody.velocity.y);
        }
        if(input > 0 && faceRight == false)
        {
            filp();
        }
        if(input < 0 && faceRight == true)
        {
            filp();
        }
        if (jump)
        {
            heroBody.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position,
                                        1 << LayerMask.NameToLayer("Ground"));
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    void filp()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
