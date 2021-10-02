using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float bombTimer;
    private float startTimer;

    public Player player;

    public bool explosion = false;

    private void Start()
    {
        startTimer = Random.Range(5f, 10f);
        bombTimer = startTimer;
        Debug.Log(bombTimer);
    }

    private void Update()
    {
        bombTimer -= Time.deltaTime;
        if(bombTimer <= 0)
        {
            explosion = true;
            //instantiate explosion
            //Instantiate();
            Destroy(gameObject);
        }
    }
}
