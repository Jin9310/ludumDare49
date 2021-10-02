using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Player player;

    public bool searchIsDone = false;

    public bool runTimer = false;


    private float currentAmount;
    private float startAmount = 0f;
    private float speed = 20f;

    private void Update()
    {
        if(runTimer == true)
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
