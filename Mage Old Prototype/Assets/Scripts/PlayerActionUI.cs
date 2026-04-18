using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionUI : MonoBehaviour
{
    public static PlayerActionUI Instance { get; private set; }

    public event EventHandler OnAttackButtonPressed;
    public event EventHandler OnHealButtonPressed;

    private bool isAttacking; 
    [SerializeField] private Button attackButton;
    [SerializeField] private Button healButton;
    [SerializeField] private TextMeshProUGUI healCountText;


    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        attackButton.onClick.AddListener(() =>
        {
            OnAttackButtonPressed?.Invoke(this, EventArgs.Empty);  
            
        });

        
        healButton.onClick.AddListener(() =>
        {
            OnHealButtonPressed?.Invoke(this, EventArgs.Empty);   
        });

    }

    private void Update()
    {
        //text güncellemsini bool out fonksiyondan aldýðým için aþaðýdaki þekilde yazdým, overload fonksiyon
        int remaining;
        bool canHeal = Player.Instance.CanPlayerHeal(out remaining);
        healCountText.text = remaining.ToString();


        //týklanýnca event yollanýp player yorumlayýp ona göre saldýracak, interactable kontolü ile hem
        //gereksiz event yollamýycaz, hem de UI daha iyi gözükecek.

        if (GameManager.Instance.IsPlayerTurn())
        {
            attackButton.interactable = true;
            if (Player.Instance.CanPlayerHeal())
            {
                healButton.interactable = true;
            }
            else
            {
                healButton.interactable = false;
            }
        }
        else
        {
            attackButton.interactable = false;
            healButton.interactable = false;
        }

    }

}
