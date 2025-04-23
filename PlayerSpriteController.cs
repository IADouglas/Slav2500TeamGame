using UnityEngine;
using static PlayerMovement;

public class PlayerSpriteController : MonoBehaviour
{
    /*RunLeft,
        RunRight,
        IdleLeft,
        IdleRight,
        JumpLeft,
        JumpRight,*/

    private SpriteRenderer sR;

    public Sprite run1;
    public Sprite run2;
    public Sprite idle1;
    public Sprite idle2;
    public Sprite jump1;
    public float frameCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameCount = (frameCount + 1) % 50;
        switch (GetComponent<PlayerMovement>().pState) 
        {
            case playerState.RunRight:
                sR.sprite = (frameCount > 24 )? run1: run2;
                sR.flipX = false;
                break;
            case playerState.RunLeft:
                sR.sprite = (frameCount > 24) ? run1 : run2;
                sR.flipX = true;
                break;
            case playerState.IdleRight:
                sR.sprite = (frameCount > 24) ? idle1 : idle2;
                sR.flipX = false;
                break;
            case playerState.IdleLeft:
                sR.sprite = (frameCount > 24) ? idle1 : idle2;
                sR.flipX = true;
                break;
            case playerState.JumpRight:
                sR.sprite = (frameCount > 24) ? run1 : run2;
                sR.flipX = false;
                break;
            case playerState.JumpLeft:
                sR.sprite = (frameCount > 24) ? run1 : run2;
                sR.flipX = true;
                break;
        }
    }
}
