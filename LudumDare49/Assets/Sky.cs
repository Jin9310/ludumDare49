using UnityEngine;

public class Sky : MonoBehaviour
{
    private float speed = 0.3f;
    private int pickDirection;

    void Start()
    {

        pickDirection = Random.Range(0, 2);
        

    }

    private void Update()
    {
        if (pickDirection == 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

}
