using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BuildingManager : MonoBehaviour
{
    //new buildings need to have its own TAG and needs to be "registered" in Player script OnEnterTrigger and OnTriggerExit


    [SerializeField] private int house01;
    [SerializeField] private int house02;
    //add new buildings here

    public Building building;
    public Building02 building02;
    //add new buildings here

    //public int[] numberCollection;

    public int houseNumberWithBomb;

    public GameObject whereIsTheBomb;
    public TMP_Text text;
    [SerializeField] private bool bombIsActive = false;

    public Player player;


    private float newTimer;
    private float startNewTimer;


    private void Start()
    {
        startNewTimer = Random.Range(4, 10);
        newTimer = startNewTimer;

        house01 = building.houseNumber;
        house02 = building02.houseNumber;
        //add new buildings here

        /*
        int[] numberCollection = new int[] { house01, house02 };

        //Debug.Log(numberCollection[0]);
        //Debug.Log(numberCollection[1]);

        int thisHouse = Random.Range(0, numberCollection.Length);
        houseNumberWithBomb = numberCollection[thisHouse];
        */
        WhereIsBomb();
        bombIsActive = true;
        //Debug.Log(houseNumberWithBomb);

    }

    private void Update()
    {
        if(bombIsActive == true)
        {
            whereIsTheBomb.SetActive(true);
            text.text = "New bomb in building no. #" + houseNumberWithBomb;
        }

        if (player.holdingBomb == true)
        {
            bombIsActive = false;
            whereIsTheBomb.SetActive(false);
        }

        if(bombIsActive == false)
        {
            newTimer -= Time.deltaTime;
            if(newTimer <= 0)
            {
                WhereIsBomb();
                bombIsActive = true;
                newTimer = startNewTimer;
            }
        }
    }

    private void WhereIsBomb()
    {
        //add new buildings into the array
        int[] numberCollection = new int[] { house01, house02 };
        int thisHouse = Random.Range(0, numberCollection.Length);
        houseNumberWithBomb = numberCollection[thisHouse];
    }

}
