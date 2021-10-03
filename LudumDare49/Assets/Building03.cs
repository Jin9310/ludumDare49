using UnityEngine;

public class Building03 : MonoBehaviour
{
    public int houseNumber;

    private void Start()
    {
        houseNumber = Random.Range(800, 900);
        //Debug.Log("house2 : " + houseNumber);
    }
}
