using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    //movement
    private float _moveInput;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed;

    private bool _facingRight = true;

    //STATES
    [SerializeField] private bool insideTheHouse = false;
    //pressing ESC will enable player to escape from the house
    public bool holdingBomb = false;
    //will affect players running walk ability
    //will slow him down
    [SerializeField] private bool nearHouse = false;
    //if near the house player can either enter or read the sign (house number)
    public bool houseWithBomb = true;

    private int health = 1;

    public float _searchTimer;
    private float _startTimer = 5f;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public GameObject houseSigns;
    public GameObject houseNumber;
    public TMP_Text text;

    public GameObject dropBomb;
    public GameObject pickUpBomb;
    public GameObject bomb;

    public GameObject searchBar;
    public ProgressBar progressBar;

    //BUILDINGS
    public BuildingManager bm;
    public int myNumber;

    public Building building01;
    public Building02 building02;
    //add new buildings here


    //bomb timer
    public float bombasticTimer;
    public float randomBombStart;


    private void Start()
    {
        randomBombStart = Random.Range(20, 30);
        bombasticTimer = randomBombStart;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        _runSpeed = _walkSpeed * 2;

        //house searching
        _searchTimer = _startTimer;
    }

    private void FixedUpdate()
    {
        _moveInput = Input.GetAxis("Horizontal");

        if (holdingBomb != true)
        {
            //don' t move the character while inside the building
            if (insideTheHouse != true)
            {
                Move(1);
            }  
        }else
        {
            //don' t move the character while inside the building
            if (insideTheHouse != true)
            {
                Move(2);
            }
        }
        
        //flip the character to the correct side
        if(_facingRight == false && _moveInput > 0)
        {
            Flip();
        }else if(_facingRight == true && _moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        //get into the house
        if(nearHouse == true && Input.GetKeyDown(KeyCode.E))
        {
            //hide players sprite
            sr.enabled = false;
            insideTheHouse = true;
            progressBar.runTimer = true;

            //hide the signs
            houseSigns.SetActive(false);
        }

        //get out of the house
        if(insideTheHouse == true && Input.GetKeyDown(KeyCode.Escape))
        {
            //make players sprite visible again
            sr.enabled = true;
            insideTheHouse = false;
            progressBar.runTimer = false;
            searchBar.SetActive(false);
        }

        if(insideTheHouse == true)
        {
            searchBar.SetActive(true);
            
            //_searchTimer -= Time.deltaTime;
            //if(_searchTimer <= 0)

            if (progressBar.searchIsDone == true)
            {
                anim.SetBool("isIdle", false);
                if(bm.houseNumberWithBomb == myNumber)
                {
                    holdingBomb = true;
                    anim.SetBool("isIdleWithBomb", true);
                }
                else
                {
                    Debug.Log("wrong house dude!");
                }
                //Exit the house [ESC]
                //change the sprite - so perhaps the animation
                searchBar.SetActive(false);
                insideTheHouse = false;
                sr.enabled = true;
                progressBar.searchIsDone = false;
            }
        }

        if(holdingBomb == true)
        {
            bombasticTimer -= Time.deltaTime;
            dropBomb.SetActive(true);
        }else
        {
            dropBomb.SetActive(false);
        }

        if(holdingBomb == true && Input.GetKeyDown(KeyCode.E))
        { 
            holdingBomb = false;
            Instantiate(bomb, transform.position, Quaternion.identity);
            anim.SetBool("isIdle", true);
            anim.SetBool("isIdleWithBomb", false);
        }

        if(bombasticTimer <= 0)
        {
            Die();
        }

    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Move(int hold)
    {
        //walk
        rb.velocity = new Vector2((_moveInput * _walkSpeed)/hold, rb.velocity.y);
        /*
        if(holdingBomb != true)
        {
            //place for walk animation to start
        }
        else
        {
            //place for walk animation with bomb to start
        }*/

        //run
        if (_moveInput != 0 && Input.GetKey(KeyCode.LeftShift) == true)
        {
            rb.velocity = new Vector2((_moveInput * _runSpeed)/hold, rb.velocity.y);
            /*
            if (holdingBomb != true)
            {
                //place for run animation to start
            }
            else
            {
                //place for run animation with bomb to start
            }*/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("building01") == true)
        {
            if(insideTheHouse != true && !holdingBomb)
            {
                nearHouse = true;
                houseSigns.SetActive(true);
                houseNumber.SetActive(true);
                //bellow line is needed for each new building
                myNumber = building01.houseNumber;
                //
                text.text = myNumber.ToString();
            }
        }

        if (collision.CompareTag("building02") == true)
        {
            if (insideTheHouse != true && !holdingBomb)
            {
                nearHouse = true;
                houseSigns.SetActive(true);
                houseNumber.SetActive(true);
                //
                myNumber = building02.houseNumber;
                //
                text.text = myNumber.ToString();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("building01") == true)
        {
            if (insideTheHouse != true)
            {
                nearHouse = false;
                houseSigns.SetActive(false);
                houseNumber.SetActive(false);
            }
        }

        if (collision.CompareTag("building02") == true)
        {
            if (insideTheHouse != true)
            {
                nearHouse = false;
                houseSigns.SetActive(false);
                houseNumber.SetActive(false);
            }
        }
    }

    private void Die()
    {
        if(health <= 0)
        {
            //instantiate death animation
            Debug.Log("Boooom! You are dead");
            //wait for the end of the animation and move to finish screen
            
        }
    }
}
