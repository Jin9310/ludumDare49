using UnityEngine;

public class Building02 : MonoBehaviour
{
    public int houseNumber;

    private void Start()
    {
        houseNumber = Random.Range(400, 500);
        //Debug.Log("house2 : " + houseNumber);
    }
}
