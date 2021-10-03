using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCleaningScript : MonoBehaviour
{
    private float deathTimer = 6f;

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
