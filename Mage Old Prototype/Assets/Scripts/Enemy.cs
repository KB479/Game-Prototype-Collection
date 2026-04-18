using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour, IHasHealthBar
{
    public event EventHandler<IHasHealthBar.OnHealthChangedEventArgs> OnHealthChanged;
    public event EventHandler OnEnemyAttack;

    private float enemyHealthMax = 100f;
    private float enemyHealth; 
    private bool canEnemyAttack = false;
    private float enemyWaits = 2f;

    [SerializeField] private ParticleSystem hitTakenParticle;
    [SerializeField] private ParticleSystem enemyDeadParticle;
    [SerializeField] private GameObject enemyVisual; 


    private void Awake()
    {
        enemyHealth = enemyHealthMax; 
    }

    private void Start()
    {
        Player.Instance.OnAttack += Player_OnAttack;
        GameManager.Instance.OnTurnChanged += GameManager_OnTurnChanged;        

    }

    //chat starta yazma dedi? 
    private void OnEnable()
    {
        MagicPopUp.OnPressRated += MagicPopUp_OnPressRated;
    }
    private void OnDisable()
    {
        MagicPopUp.OnPressRated -= MagicPopUp_OnPressRated;
    }


    private void MagicPopUp_OnPressRated(object sender, MagicPopUp.OnPressRatedEventArgs e)
    {
        int damage = 0;

        switch (e.rating)
        {
            case "Perfect!":
                damage = 30;
                break;
            case "Good!":
                damage = 15;
                break;
            case "Missed!":
                damage = 1;
                break;
        }

        TakeDamage(damage); 
    
    }

    private void GameManager_OnTurnChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        if(e.state == GameManager.State.EnemysTurn)
        {
            canEnemyAttack = true;
        }
        else
        {
            canEnemyAttack = false;
        }
    }

    public void Update()
    {
        if (IsEnemyAlive() && canEnemyAttack)
        {

            enemyWaits -= Time.deltaTime;

            if(enemyWaits <= 0)
            {
                EnemyAttack();
                enemyWaits = 2f; 
            }

        }

    
    }


    private void Player_OnAttack(object sender, EventArgs e)
    {
        //Playerýn baþarýlý vuruþ ratingine göre enemy canýný güncelleyecek. 
        //Random hem UnityEngine hem de System'da var o yüzden referans belirt.
        //Attack rating olmadýðý için þimdilik magic numbers

        /*enemyHealth -= UnityEngine.Random.Range(10f, 20f);

        OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs
        {
            healthNormalized = enemyHealth / enemyHealthMax
        }); 

        if(IsEnemyAlive() == true)
        {
            Instantiate(hitTakenParticle, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyDeadParticle, transform.position, Quaternion.identity); 
        }
        */
    }


    private void TakeDamage(int damage)
    {
        enemyHealth -= damage; 

        OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs
        {
            healthNormalized = enemyHealth / enemyHealthMax
        });

        if (IsEnemyAlive() == true)
        {
            Instantiate(hitTakenParticle, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyDeadParticle, transform.position, Quaternion.identity);
        }
    }

    private void EnemyAttack()
    {

        OnEnemyAttack?.Invoke(this, EventArgs.Empty);
    }

    public bool IsEnemyAlive()
    {
        if (enemyHealth <= 0)
        {
            //logic - visual karýþmýþ, düzelt. 
            enemyVisual.SetActive(false);
            return false;
        }
        else
        {
            enemyVisual.SetActive(true); 
            return true;
        }
    }


    //Fast kill için konuldu
    public void KillEnemy()
    {
        enemyHealth = 0f;
        Instantiate(enemyDeadParticle, transform.position, Quaternion.identity);

        OnHealthChanged?.Invoke(this, new IHasHealthBar.OnHealthChangedEventArgs
        {
            healthNormalized = enemyHealth / enemyHealthMax
        });
    }


}
