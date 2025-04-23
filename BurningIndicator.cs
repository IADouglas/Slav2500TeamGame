using UnityEngine;
using UnityEngine.SceneManagement;

public class BurningIndicator : MonoBehaviour
{

    public float health = 3;

    public GameObject burn;
    public float burnTimer = 0f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        burn.SetActive(false);
        health = 3;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (burnTimer > 0) 
        {
            burnTimer -= 1;
            if (burnTimer == 0 && burn.activeInHierarchy)
            {
                
                
                Debug.Log("Taking Damage!");
                Damage();
                
            }//Damage stuff
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Burn() 
    {
        burnTimer += 50f;
        burn.SetActive(true);
    }

    public void EscapedBurn() 
    {
        burnTimer = 0f;
        burn.SetActive(false);
    }

    public void Damage() 
    {
        health -= 1;
        if (burn.activeInHierarchy) { burnTimer += 150f; }
        rb.AddForce(Vector3.up * 5 + new Vector3(1, 0, 0) * 7, ForceMode2D.Impulse);
    }


}
