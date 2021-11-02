using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenStats : MonoBehaviour
{
    public TMP_Text numberOfExp;
    public TMP_Text numberOfDefuses;
    public TMP_Text unsafeExps;

    public TMP_Text deathMessage;

    void Start()
    {

        var totalExp = DropZone.numberOfExplosions;
        var totalDefuse = DropZone.defusedBombsCount;
        var unsafeExp = totalExp - totalDefuse;

        if (DropZone.houseExploded == true)
        {
            deathMessage.text = "A house exploded... That shouldn't be happening!";
        }else if (DropZone.playerExploded == true)
        {
            deathMessage.text = "Your body has been torn apart... our medicine can' t fix that yet. Avoid the explosions ;)";
        }
        else if (DropZone.playerFell == true)
        {
            deathMessage.text = "You had to try it right?";
        }

        //Debug.Log("number of expolosions: " + totalExp);
        //Debug.Log("defused bombs: " + totalDefuse);
        //Debug.Log("unsafe explosions: " + unsafeExp);

        numberOfExp.text = "number of expolosions: " + totalExp;
        numberOfDefuses.text = "defused bombs: " + totalDefuse;
        unsafeExps.text = "unsafe explosions: " + unsafeExp;
    }
}
