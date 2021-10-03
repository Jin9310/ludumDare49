using UnityEngine;

public class CleaningScript : MonoBehaviour
{
    private float deathTimer = 1f;

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        if(deathTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
