using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator animator;

    private const string ATTACK = "Attack";
    private const string DEFEND = "Defend";
    private const string IS_ENEMY_DEAD = "IsEnemyDead";
    private const string IS_PLAYER_DEAD = "IsPlayerDead";


    [SerializeField] private Enemy enemy; 


    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        // Normal attack için dinleme: 
        enemy.OnEnemyAttack += Enemy_OnEnemyAttack;
        MagicPopUp.OnPressRated += MagicPopUp_OnPressRated;

        //fast kill için dinleme: 
        FastKillControlUI.Instance.OnPlayerFastKill += FastKillControlUI_OnPlayerFastKill;
        FastKillControlUI.Instance.OnEnemyFastKill += FastKillControlUI_OnEnemyFastKill;
    }

    private void OnEnable()
    {
 

    }

    private void OnDisable()
    {
        MagicPopUp.OnPressRated -= MagicPopUp_OnPressRated;
    }


    private void MagicPopUp_OnPressRated(object sender, MagicPopUp.OnPressRatedEventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }
    private void Enemy_OnEnemyAttack(object sender, System.EventArgs e)
    {
        animator.SetTrigger(DEFEND);
    }

    private void FastKillControlUI_OnEnemyFastKill(object sender, System.EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }

    private void FastKillControlUI_OnPlayerFastKill(object sender, System.EventArgs e)
    {
        animator.SetTrigger(DEFEND);
    }


    private void Update()
    {

        if (enemy.IsEnemyAlive() == false)
        {
            animator.SetBool(IS_ENEMY_DEAD, true); 
        }
        
        if(Player.Instance.IsPlayerAlive() == false)
        {
            animator.SetBool(IS_PLAYER_DEAD, true); 
        }

    }

}
