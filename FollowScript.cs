using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = (Vector2)player.transform.position;//+ ( Vector2.up * 2f); 
        Vector3 pos = new Vector3(player.transform.position.x,0,0) + new Vector3(6.77f,4.5f,-10f);
        //Vector3 smoothedPos = Vector3.Lerp(transform.position, pos, 0.5f);
        transform.position = pos;

    }
}
