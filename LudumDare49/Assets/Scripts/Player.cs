using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //movement
    private float _moveInput;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed;

    private bool _facingRight = true;

    public bool throwBomb = false;

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
    public Building03 building03;
    public Building04 building04;
    //add new buildings here


    //bomb timer
    public float bombasticTimer;
    public float randomBombStart;

    public GameObject countDown;
    public TMP_Text textCoundown;

    public GameObject exploFX;


    private void Start()
    {
        randomBombStart = Random.Range(10, 30);
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
                // 2 is for walk while holding the bomb
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

        if(_moveInput == 0 && holdingBomb != true)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isIdleWithBomb", false);
            anim.SetBool("walk", false);
            anim.SetBool("walkWithBomb", false);
        }
        else if(_moveInput == 0 && holdingBomb == true)
        {
            anim.SetBool("isIdleWithBomb", true);
            anim.SetBool("isIdle", false); 
            anim.SetBool("walk", false);
            anim.SetBool("walkWithBomb", false);
        }
        else if(_moveInput != 0 && holdingBomb != true)
        {
            anim.SetBool("walk", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isIdleWithBomb", false);
            anim.SetBool("walkWithBomb", false);
        }
        else if(_moveInput != 0 && holdingBomb == true)
        {
            anim.SetBool("walkWithBomb", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isIdleWithBomb", false);
            anim.SetBool("walk", false);
        }
        
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
            //if player drops the bomb, timer needs to be reset
            randomBombStart = Random.Range(10, 30);
            bombasticTimer = randomBombStart;

            dropBomb.SetActive(false);
        }

        if(holdingBomb == true && Input.GetKeyDown(KeyCode.E))
        {
            throwBomb = false;
            holdingBomb = false;
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 1, -4), Quaternion.identity);
            
            anim.SetBool("isIdleWithBomb", false);
            if(_moveInput != 0)
            {
                anim.SetBool("walk", true);
                anim.SetBool("walkWithBomb", false);
            }else
            {
                anim.SetBool("isIdle", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(bomb, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        }

        if (bombasticTimer <= 0)
        {
            Die();
            bombasticTimer = randomBombStart;
        }

        if(bombasticTimer <= 10 && holdingBomb == true)
        {
            countDown.SetActive(true);
            var timeToDie = Mathf.Round(bombasticTimer);
            textCoundown.text = timeToDie.ToString();
        }else
        {
            countDown.SetActive(false);
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
        if(holdingBomb != true && _moveInput != 0)
        {
            //place for walk animation to start
            anim.SetBool("walk", true);
        }
        else if(holdingBomb != false && _moveInput != 0)
        {
            anim.SetBool("walk", true);
        }*/

        //run
        if (_moveInput != 0 && Input.GetKey(KeyCode.LeftShift) == true)
        {
            rb.velocity = new Vector2((_moveInput * _runSpeed)/hold, rb.velocity.y);/*
            anim.SetBool("walk", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isIdleWithBomb", false);*/
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

        if (collision.CompareTag("building03") == true)
        {
            if (insideTheHouse != true && !holdingBomb)
            {
                nearHouse = true;
                houseSigns.SetActive(true);
                houseNumber.SetActive(true);
                //
                myNumber = building03.houseNumber;
                //
                text.text = myNumber.ToString();
            }
        }

        if (collision.CompareTag("building04") == true)
        {
            if (insideTheHouse != true && !holdingBomb)
            {
                nearHouse = true;
                houseSigns.SetActive(true);
                houseNumber.SetActive(true);
                //
                myNumber = building04.houseNumber;
                //
                text.text = myNumber.ToString();
            }
        }

        if (collision.CompareTag("Edge") == true)
        {
            Die();
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

        if (collision.CompareTag("building03") == true)
        {
            if (insideTheHouse != true)
            {
                nearHouse = false;
                houseSigns.SetActive(false);
                houseNumber.SetActive(false);
            }
        }

        if (collision.CompareTag("building04") == true)
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
        health--;
        if(health <= 0)
        {
            //instantiate death animation
            Instantiate(exploFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene("03EndScreen");
            Debug.Log("Player Died");
            //wait for the end of the animation and move to finish screen
            
        }
    }
}
