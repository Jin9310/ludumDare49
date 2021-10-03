using UnityEngine;

public class DropZone : MonoBehaviour
{

    public int defusedBombsCount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            defusedBombsCount++;
            //Debug.Log(defusedBombsCount);
        }
    }
}
