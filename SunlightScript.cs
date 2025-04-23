using UnityEngine;

public class SunlightScript : MonoBehaviour
{
    public Transform goal;
    private Vector3 end;
    private Vector3 currentLoc;
    public float sunSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        end = goal.transform.position;
        //currentLoc = Vector3.Lerp(transform.position,end,100f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position +=new Vector3(sunSpeed,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<BurningIndicator>().Burn();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<BurningIndicator>().EscapedBurn();

        }
    }
}
