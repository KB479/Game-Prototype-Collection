using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{

    private enum EastTeamList
    {
        CAVS, 
        BUCKS, 
        NYK,
    }

    Dictionary<EastTeamList, int> eastTeamsPowerPair;
    Dictionary<string, int> westTeamsPowerPair; 

    private void Awake()
    {
        eastTeamsPowerPair = new Dictionary<EastTeamList, int>();

        // List gibi Add-Remove da yapabiliriz
        eastTeamsPowerPair[EastTeamList.CAVS] = 90;
        eastTeamsPowerPair[EastTeamList.BUCKS] = 95;
        eastTeamsPowerPair[EastTeamList.NYK] = 55;


        Debug.Log("East Teams: ");
        foreach(var team in eastTeamsPowerPair)
        {
            Debug.Log($"Team: {team.Key} , Power: {team.Value} "); 
        }


        // Bu syntaxý unutuyorum iþte, arrays gibi baþlangýç deðeri ile initialize etmek için: 
        westTeamsPowerPair = new Dictionary<string, int>()
        {
            {"OKC" , 95 },
            {"GSW" , 80 },
            {"LAL" , 80 },

        };

        westTeamsPowerPair["GSW"] = 75; 

        Debug.Log("West Teams: "); 
        foreach (var team in westTeamsPowerPair)
        {
            Debug.Log($"Team: {team.Key} , Power: {team.Value} ");
        }

    }

    private void Start()
    {
        if (westTeamsPowerPair.TryGetValue("LAL", out int gswPowerRank))
        {
            Debug.Log(gswPowerRank); 
        }
    }

}
