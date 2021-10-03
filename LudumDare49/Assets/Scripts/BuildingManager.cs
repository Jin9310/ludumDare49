using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BuildingManager : MonoBehaviour
{
    //new buildings need to have its own TAG and needs to be "registered" in Player script OnEnterTrigger and OnTriggerExit


    [SerializeField] private int house01;
    [SerializeField] private int house02;
    [SerializeField] private int house03;
    [SerializeField] private int house04;
    //add new buildings here

    public Building building;
    public Building02 building02;
    public Building03 building03;
    public Building04 building04;
    //add new buildings here

    //public int[] numberCollection;

    public int houseNumberWithBomb;

    public GameObject whereIsTheBomb;
    public TMP_Text text;

    public GameObject instructions;
    public TMP_Text textInstructions;
    [SerializeField] private bool bombIsActive = false;

    public Player player;


    private float newTimer;
    private float startNewTimer;

    public float tickTock;
    private float startTickTock = 25f;
    public bool houseExplode = false;


    private void Start()
    {
        tickTock = startTickTock;
        startNewTimer = Random.Range(4, 10);
        newTimer = startNewTimer;

        house01 = building.houseNumber;
        house02 = building02.houseNumber;
        house03 = building03.houseNumber;
        house04 = building04.houseNumber;
        //add new buildings here

        WhereIsBomb();
        bombIsActive = true;

    }

    private void Update()
    {
        if(bombIsActive == true)
        {
            whereIsTheBomb.SetActive(true);
            text.text = "New bomb in building no. #" + houseNumberWithBomb;

            tickTock -= Time.deltaTime;
            if(tickTock <= 0)
            {
                houseExplode = true;
                tickTock = startTickTock;
                bombIsActive = false;
            }
        }

        if (player.holdingBomb == true)
        {
            instructions.SetActive(true);
            textInstructions.text = "Get rid of the bomb!";
            bombIsActive = false;
            whereIsTheBomb.SetActive(false);
        }else if(player.holdingBomb == false)
        {
            instructions.SetActive(false);
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
        int[] numberCollection = new int[] { house01, house02, house03, house04 };
        int thisHouse = Random.Range(0, numberCollection.Length);
        houseNumberWithBomb = numberCollection[thisHouse];
    }

}