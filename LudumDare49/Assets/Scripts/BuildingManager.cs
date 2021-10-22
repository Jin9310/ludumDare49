using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;

public class BuildingManager : MonoBehaviour
{
    //new buildings need to have its own TAG and needs to be "registered" in Player script OnEnterTrigger and OnTriggerExit


    [SerializeField] private int house01;
    [SerializeField] private int house02;
    [SerializeField] private int house03;
    [SerializeField] private int house04;
    public int thisHouse;
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


    public int helpMe;

    //this is timer for new bomb to appear in new house
    private float newTimer;
    private float startNewTimer;

    //once the above timer is done, below timer needs to start and if this one runs off, house will explode
    public float tickTock;
    private float startTickTock = 25f;
    public bool houseExplode = false;

    //this should help to show the explosion
    public float deadHouseTimer = 3f;

    //camera
    public CinemachineVirtualCamera vcam;
    public Transform targetPlayer;
    public Transform targetBuilding0;
    public Transform targetBuilding02;
    public Transform targetBuilding04;


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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            targetBuilding04 = building04.transform;
            vcam.LookAt = targetBuilding04;
            vcam.Follow = targetBuilding04;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            targetPlayer = player.transform;
            vcam.LookAt = targetPlayer;
            vcam.Follow = targetPlayer;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetBuilding0 = building.transform;
            vcam.LookAt = targetBuilding0;
            vcam.Follow = targetBuilding0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetBuilding02 = building02.transform;
            vcam.LookAt = targetBuilding02;
            vcam.Follow = targetBuilding02;
        }


        if (bombIsActive == true)
        {
            whereIsTheBomb.SetActive(true);
            text.text = "New bomb in building no. #" + houseNumberWithBomb;

            tickTock -= Time.deltaTime;
            if(tickTock <= 0)
            {
                houseExplode = true;
                bombIsActive = false;
                tickTock = startTickTock;
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
            //this needs to be here in order to restart the timer of ticking bomb again
            tickTock = startTickTock;

            newTimer -= Time.deltaTime;
            if(newTimer <= 0)
            {
                WhereIsBomb();
                bombIsActive = true;
                newTimer = startNewTimer;
            }
        }

        if(building.houseIsDead == true || building02.houseIsDead == true || building03.houseIsDead == true || building04.houseIsDead == true)
        {
            switch (thisHouse)
            {
                case 0:
                    targetBuilding0 = building.transform;
                    vcam.LookAt = targetBuilding0;
                    vcam.Follow = targetBuilding0;
                    break;
                case 1:
                    targetBuilding02 = building02.transform;
                    vcam.LookAt = targetBuilding02;
                    vcam.Follow = targetBuilding02;
                    break;
                case 2:
                    targetBuilding04 = building04.transform;
                    vcam.LookAt = targetBuilding04;
                    vcam.Follow = targetBuilding04;
                    break;
            }

            deadHouseTimer -= Time.deltaTime;
            if(deadHouseTimer <= 0)
            {
                SceneManager.LoadScene("03EndScreen");
            }
        }
    }

    private void WhereIsBomb()
    {
        //add new buildings into the array
        int[] numberCollection = new int[] { house01, house02, house04 };
        thisHouse = Random.Range(0, numberCollection.Length);
        houseNumberWithBomb = numberCollection[thisHouse];
        Debug.Log(thisHouse);
        helpMe = houseNumberWithBomb;
    }

}
