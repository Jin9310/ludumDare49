using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Player player;
    private AudioSource audioSource;

    public bool searchIsDone = false;

    public bool runTimer = false;


    public float currentAmount;
    private float startAmount = 0f;
    private float speed = 20f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (runTimer == true)
        {
            currentAmount += speed * Time.deltaTime;
            if(currentAmount >= 100)
            {
                runTimer = false;
                searchIsDone = true;
                currentAmount = startAmount;
            }
        }
        

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }


}
