using UnityEngine;

public class Building : MonoBehaviour
{

    public int houseNumber;

    private void Start()
    {
        houseNumber = Random.Range(100, 200);
        //Debug.Log("house1 : " + houseNumber);
    }

}
