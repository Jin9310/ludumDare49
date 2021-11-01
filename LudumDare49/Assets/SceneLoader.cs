using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        DropZone.numberOfExplosions = 0;
        DropZone.defusedBombsCount = 0;
        SceneManager.LoadScene("02Game");
    }
}
