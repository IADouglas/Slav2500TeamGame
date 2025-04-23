using UnityEngine;

public class HealthUIScript : MonoBehaviour
{
    public GameObject player;
    public float healthVal;
    private SpriteRenderer sR;

    public Sprite Filled;
    public Sprite Empty;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealth = player.GetComponent<BurningIndicator>().health;
        if (healthVal > currentHealth) 
        {
            sR.sprite = Empty;
        }
        else 
        {
            sR.sprite = Filled;
        }
    }
}
