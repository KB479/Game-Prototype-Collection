using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private Transform magicPopUp;
    [SerializeField] private RectTransform canvasTransform; 
    [SerializeField] private RectTransform spawnArea;

    //private bool isPopUpSpawned = false;


    public void Start()
    {
        Player.Instance.OnAttack += Player_OnAttack;

        //GameManager.Instance.OnTurnChanged += GameManager_OnTurnChanged;
        
    }

    private void Player_OnAttack(object sender, System.EventArgs e)
    {
        PopUpCreater();


    }




    /*
    private void GameManager_OnTurnChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        
        if (e.state == GameManager.State.PlayersTurn && Player.Instance.IsPlayerAlive())
        {
            if (!isPopUpSpawned)
            {
                PopUpCreater();
                isPopUpSpawned = true;
            }
        }
        else
        {
            isPopUpSpawned = false;
        }
   

    }

    */

    public void PopUpCreater()
    {
        //Þimdilik 1 çýksýn popuplar dinamik deðil daha birbirleri içine giriyor. 

        int popUpCount = 1;

        Vector2 areaCenter = spawnArea.anchoredPosition;
        Vector2 areaSize = spawnArea.sizeDelta;

        for (int i = 0; i < popUpCount; i++)
        {
            GameObject popup = Instantiate(magicPopUp.gameObject, canvasTransform);
            RectTransform popupRect = popup.GetComponent<RectTransform>();

            float randomX = Random.Range(areaCenter.x - areaSize.x / 2f, areaCenter.x + areaSize.x / 2f);
            float randomY = Random.Range(areaCenter.y - areaSize.y / 2f, areaCenter.y + areaSize.y / 2f);


            popupRect.anchoredPosition = new Vector2(randomX, randomY);
        }


    }









}
