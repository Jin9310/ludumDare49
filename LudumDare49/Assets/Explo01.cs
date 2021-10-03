using UnityEngine;
using UnityEngine.SceneManagement;

public class Explo01 : MonoBehaviour
{
    private float deathTimer = 2f;

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            //SceneManager.LoadScene("01Menu");
            Destroy(gameObject);
        }
    }
}
