using UnityEngine;

public class Building03 : MonoBehaviour
{
    public int houseNumber;

    private void Start()
    {
        houseNumber = Random.Range(1, 100);
        //Debug.Log("house2 : " + houseNumber);
    }
}
