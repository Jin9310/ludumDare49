using UnityEngine;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour
{

    public int houseNumber;
    public bool houseIsDead = false;

    public BuildingManager bm;
    public GameObject explosion;
    //sound
    public GameObject blast;

    //debris
    public GameObject debris01;
    public GameObject debris02;
    public GameObject debris03;
    public GameObject debris04;
    public GameObject debris05;
    public GameObject debris06;
    public GameObject debris07;
    public GameObject debris08;
    public GameObject debris09;
    public GameObject debris10;

    private void Start()
    {
        houseNumber = Random.Range(100, 200);
        //Debug.Log("house1 : " + houseNumber);
    }

    private void Update()
    {
        if(houseNumber == bm.houseNumberWithBomb && bm.houseExplode == true)
        {
            
            for(int i = 0; i < 11; i++)
            {
                //instantiate debris
                Instantiate(debris01, transform.position, Quaternion.identity);
                Instantiate(debris02, transform.position, Quaternion.identity);
                Instantiate(debris03, transform.position, Quaternion.identity);
                Instantiate(debris04, transform.position, Quaternion.identity);
                Instantiate(debris05, transform.position, Quaternion.identity);
                Instantiate(debris06, transform.position, Quaternion.identity);
                Instantiate(debris07, transform.position, Quaternion.identity);
                Instantiate(debris08, transform.position, Quaternion.identity);
                Instantiate(debris09, transform.position, Quaternion.identity);
                Instantiate(debris10, transform.position, Quaternion.identity);
                Debug.Log(i);
            }
            Instantiate(explosion, transform.position, Quaternion.identity);
            //sound
            Instantiate(blast, transform.position, Quaternion.identity);
            houseIsDead = true;
            //SceneManager.LoadScene("03EndScreen");
            Destroy(gameObject);
            Debug.Log("You have lost house number " + houseNumber);
        }
    }

}
