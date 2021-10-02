using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Player player;

    public bool searchIsDone = false;


    private float currentAmount;
    private float startAmount = 0f;
    private float speed = 20f;

    private void Update()
    {
        if(currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }

        if(currentAmount >= 100)
        {
            searchIsDone = true;
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }


}
