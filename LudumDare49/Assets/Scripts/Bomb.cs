using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float bombTimer;

    public Player player;

    private void Start()
    {
        bombTimer = player.bombasticTimer;
    }

    private void Update()
    {
        bombTimer -= Time.deltaTime;
        if(bombTimer <= 0)
        {
            //instantiate explosion
            //Instantiate();
            Destroy(gameObject);
        }
    }
}
