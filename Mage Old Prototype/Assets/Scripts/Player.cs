using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHasHealthBar
{
    public static Player Instance { get; private set; }

    public event EventHandler<IHasHealthBar.OnHealthChangedEventArgs> OnHealthChanged; 
    public event EventHandler OnAttack;
    public event EventHandler OnHeal; 

    private float playerHealthMax = 100f;
    private float playerHealth; 
    private bool canPlayerTakeAction;
    private int playerHealRemaning;
    private int playerHealMax = 3;
    private bool isAttacking;

    //private bool isAttackButtonPressed = false; 

    [SerializeField] private ParticleSystem hitTakenParticle;
    [SerializeField] private ParticleSystem healingParticle;
    [SerializeField] private Enemy enemy; 
    //Tek tek bütün enemyler için eklemiycez elbette, detay notionda!


    private void Awake()
    {
        playerHealth = playerHealthMax;
        playerHealRemaning = playerHealMax;
        Instance = this;
    }

    private void Start()
    {
        enemy.OnEnemyAttack += Enemy_OnEnemyAttack;
        GameManager.Instance.OnTurnChanged += GameManager_OnTurnChanged;
        PlayerActionUI.Instance.OnAttackButtonPressed += PlayerActionUI_OnAttackButtonPressed;
        PlayerActionUI.Instance.OnHealButtonPressed += PlayerActionUI_OnHealButtonPressed;

    }

    private void PlayerActionUI_OnHealButtonPressed(object sender, EventArgs e)
    {
        if (IsPlayerAlive() && canPlayerTakeAction)
        {
            Heal();
        }
    }

    private void PlayerActionUI_OnAttackButtonPressed(object sender, EventArgs e)
    {
        if (IsPlayerAlive() && canPlayerTakeAction)
        {
            OnAttack?.Invoke(this, EventArgs.Empty);
        }
    }

    private void GameManager_OnTurnChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        if(e.state == GameManager.State.PlayersTurn)
        {
            canPlayerTakeAction = true;
        }
        else
        {
            canPlayerTakeAction = false;
        }
    }


    private void Enemy_OnEnemyAttack(object sender, EventArgs e)
    {
        //Random hem UnityEngine hem de System'da var o yüzden referans belirt.
        //Attack rating olmadýðý için þimdilik magic numbers
        //Enemy'nin verdiði hasar playerdan random seçiliyor, bunu düzelt ilerde. 

        playerHealth -= UnityEngine.Random.Range(0f, 30f);

        Instantiate(hitTakenParticle, transform.position, Quaternion.identity);
        //CM transform ile daha temiz Instantiate yapýyordu ben kýsaca böyle yapýcam þimdilik.

        OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs{

            healthNormalized = playerHealth / playerHealthMax
        }); 
    }


    private void Attack()
    {
        
    }


    private void Heal()
    {
        // Health posion sistemi ile detaylandýrýlýr burasý, þimdilik stabil iyileþtirme
        OnHeal?.Invoke(this, EventArgs.Empty);

        playerHealRemaning--;

        Instantiate(healingParticle, transform.position, Quaternion.identity);
        //CM transform ile daha temiz Instantiate yapýyordu ben kýsaca böyle yapýcam þimdilik.

        if (playerHealth >= playerHealthMax * 4/5)
        {
            playerHealth = playerHealthMax;

            OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs
            {
                healthNormalized = playerHealth / playerHealthMax
            });
        }
        else
        {
            playerHealth += playerHealthMax / 5;
            
            OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs
            {
                healthNormalized = playerHealth / playerHealthMax
            });
        }


    }


    public bool IsPlayerAlive()
    {
        return playerHealth > 0;
    }


    //iki fonksiyonu overload yaptým, biri heal textini güncellemek için out veriyor, diðeri ise heal button
    //interactable kontrolü için kullanýlýyor. Daha temiz yazýlabilridi, þimdilik bu yeterli 
    public bool CanPlayerHeal()
    {
        return playerHealRemaning > 0;
    }

    public bool CanPlayerHeal(out int remaining)
    {
        remaining = playerHealRemaning;
        return remaining > 0;
    }


    //FastKill için 
    public void KillPlayer()
    {
        playerHealth = 0f;
        Instantiate(hitTakenParticle, transform.position, Quaternion.identity);

        OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs
        {
            healthNormalized = playerHealth / playerHealthMax
        });
    }




}
