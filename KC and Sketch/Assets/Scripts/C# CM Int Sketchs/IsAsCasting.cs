using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace Lecture
{
    public class IsAsCasting : MonoBehaviour
    {

        private void Start()
        {

            IAttackable attackable = new Player();

            attackable.Attack();
            // attackable.Interact(); çalýþmaz
            
            if(attackable is Player player)
            {
                player.Interact();  
            }

            BaseUnit unit = new Enemy();

            unit.Interact();
            //unit.Attack(); çalýþmaz

            if(unit is Enemy enemy)
            {
                enemy.Attack();
            }

   
            IAttackable attackable1 = new Player();

            if(attackable1.GetType() == typeof(Player))
            {

                //Player player1 = attackable1 as Player;
                //player1.Interact();

                Player player2 = (Player)attackable1;
                player2.Interact();
            }

        }

        public class Player : BaseUnit, IAttackable
        {
            public override void Interact()
            {
                Debug.Log("Player Interact!");
            }

            public void Attack()
            {
                Debug.Log("Player Attack!"); 
            }
        }

        public class Enemy : BaseUnit, IAttackable
        {
            public override void Interact()
            { 
                Debug.Log("Enemy Interact!");
            }

            public void Attack()
            {
                Debug.Log("Enemy Attack!");
            }

        }

        interface IAttackable
        {
            public void Attack(); 
        }

        public class BaseUnit
        {
            public virtual void Interact() { }
        }





    }

}