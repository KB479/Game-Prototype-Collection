using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    // 1- Initialize etmeden declare etmek
    public string[] spellNames;

    // 2- Boyutunu belirleyip initialize etmek
    public int[] score = new int[2];

    // 3- Direkt baþlangýç deðerleri ile initialize etmek 
    public string[] weapons = { "Kýlýç", "Balta", "Yay" };


    private void Start()
    {
        // Type 1, sadece declare edilmiþti, yani atama yapmadan önce initialize etmek gerekiyor
        spellNames = new string[3];

        spellNames[0] = "Ice";
        spellNames[1] = "Fire";
        spellNames[2] = "Air";

        Debug.Log($"1. Spell: {spellNames[0]}, 2. Spell: {spellNames[1]}, 3. Spell: {spellNames[2]}");

        // Type 2 initialize edilmiþti, direkt atama yapabiliriz
        score[0] = 20;
        score[1] = 50;
        Debug.Log($"Score 1: {score[0]}, Score 2: {score[1]}");

        // Type 3 baþlangýç deðerleri ile initialize dilmiþti, deðerler yine set edilebilir direkt
        Debug.Log($"Weapon 3: {weapons[2]}");
        weapons[2] = "SayGeks";
        Debug.Log($"New Weapon 3: {weapons[2]}");

    }


}
