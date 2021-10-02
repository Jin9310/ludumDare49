using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Player player;


    private float currentAmount;
    private float speed = 20f;

    private void Update()
    {
        if(currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }


}
