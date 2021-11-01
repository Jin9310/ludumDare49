using UnityEngine;

public class DropZone : MonoBehaviour
{

    public static int defusedBombsCount;
    public static int numberOfExplosions;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            defusedBombsCount++;
            //Debug.Log(defusedBombsCount);
        }
    }
}
