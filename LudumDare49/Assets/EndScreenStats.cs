using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenStats : MonoBehaviour
{
    public TMP_Text numberOfExp;
    public TMP_Text numberOfDefuses;
    public TMP_Text unsafeExps;

    void Start()
    {

        var totalExp = DropZone.numberOfExplosions;
        var totalDefuse = DropZone.defusedBombsCount;
        var unsafeExp = totalExp - totalDefuse;

        //Debug.Log("number of expolosions: " + totalExp);
        //Debug.Log("defused bombs: " + totalDefuse);
        //Debug.Log("unsafe explosions: " + unsafeExp);

        numberOfExp.text = "number of expolosions: " + totalExp;
        numberOfDefuses.text = "defused bombs: " + totalDefuse;
        unsafeExps.text = "unsafe explosions: " + unsafeExp;
    }
}
