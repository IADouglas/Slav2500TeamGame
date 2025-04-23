using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float moveForce = 3f;
    public float maxSpeed = 10f;
    public playerState pState;

    public enum playerState 
    {
        RunLeft,
        RunRight,
        IdleLeft,
        IdleRight,
        JumpLeft,
        JumpRight,
    
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pState = playerState.IdleRight;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        //float ver = Input.GetAxisRaw("Vertical");

        //rb.linearVelocity += new Vector2(hor * moveSpeed,0);
        if (Math.Abs(hor) > 0f)
        {

            if (Math.Abs(rb.linearVelocity.x) < maxSpeed)
            {
                rb.AddForce(new Vector2(hor,0) * moveForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded()) 
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }


        //Update state
        if (Math.Abs(rb.linearVelocityX) > 0f)
        {
            if (!Grounded())
            {
                if (rb.linearVelocityX > 0)
                {
                    pState = playerState.JumpRight;
                }
                else if (pState == playerState.RunLeft)
                {
                    pState = playerState.JumpLeft;
                }
            }
            else
            {
                if (rb.linearVelocityX > 0)
                {
                    pState = playerState.RunRight;
                }
                else
                {
                    pState = playerState.RunLeft;
                }
            }

        }
        else
        {
            if (pState == playerState.RunRight)
            {
                pState = playerState.IdleRight;
            }
            else if (pState == playerState.RunLeft) 
            {
                pState = playerState.IdleLeft;
            }
        }
        
        

    }
    private bool Grounded()
    {

        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.down * (GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.01f), Vector2.down, 0.1f, LayerMask.GetMask("terrain"));
        //Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);
        if (hit.collider != null && hit.collider.gameObject != gameObject)
        {
            return true;
        }
        //Debug.Log("DEBUG: Grounded was false!");
        return false;
    }
}
