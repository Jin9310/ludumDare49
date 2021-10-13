using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float bombTimer;
    private float startTimer;

    public Player player;
    public GameObject exploFX;

    public bool explosion = false;

    public GameObject blast;
    Rigidbody2D rb;

    /*
    private float force = 3f;
    private int randDirection;
    */

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTimer = Random.Range(2f, 5f);
        bombTimer = startTimer;
        /*
        randDirection = Random.Range(0, 2);
        if(randDirection == 0)
        {
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        }else
        {
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            rb.AddForce(transform.right * -force, ForceMode2D.Impulse);
        }
          */  

        //Debug.Log(bombTimer);
    }

    private void Update()
    {
        bombTimer -= Time.deltaTime;
        if(bombTimer <= 0)
        {
            explosion = true;
            Instantiate(exploFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Instantiate(blast, transform.position, Quaternion.identity);
            //instantiate explosion sound
            Destroy(gameObject);
        }
    }
}
