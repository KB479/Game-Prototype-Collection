using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionParams : MonoBehaviour
{

    private void Start()
    {
        SaluteCavsPlayer(3, "Donovan Mitchell", "James Harden", "Evan Mobley"); 
    }

    private void SaluteCavsPlayer(int playerNum, params string[] playerName)
    {
        Debug.Log($" The big {playerNum}:");

        for (int i = 0; i < playerName.Length; i++)
        {
            Debug.Log($"Hey {playerName[i]}!");
        }
    }


}
