using UnityEngine;

public class DropZone : MonoBehaviour
{

    public static int defusedBombsCount;
    public static int numberOfExplosions;
    public static bool houseExploded;
    public static bool playerExploded;
    public static bool playerFell;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            defusedBombsCount++;
            //Debug.Log(defusedBombsCount);
        }
    }
}
