using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        //float ver = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(hor * moveSpeed,rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded()) 
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
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
