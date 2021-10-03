using UnityEngine;

public class Building04 : MonoBehaviour
{
    public int houseNumber;

    private void Start()
    {
        houseNumber = Random.Range(300, 400);
        //Debug.Log("house2 : " + houseNumber);
    }
}
