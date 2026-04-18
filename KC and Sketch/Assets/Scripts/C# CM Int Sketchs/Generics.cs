using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Lecture
{
    public class Generics : MonoBehaviour
    {
       

        public class MyList<T>
        {
            public T[] values = new T[4];
        }


        public class SpawnManager<T> where T : BaseClass
        {         
            public void Spawn(T t)
            {
                Debug.Log("Spawned: " + t.GetType());
            }
        }

        private void PrintFunctionParameters<T>(T t)
        {
            Debug.Log("This function's parameter is a type of: " + t.GetType());
        }


        private void Awake()
        {
            List<int> list = new List<int>(); 

            // Generic class + where örneði
            SpawnManager<Player> spawnPlayerManager = new SpawnManager<Player>();
            Player player = new Player();
            spawnPlayerManager.Spawn(player);


            //Generic fonksiyon örneði: 
            PrintFunctionParameters(5);
            PrintFunctionParameters("Hi!"); 
            PrintFunctionParameters(spawnPlayerManager);

            Enemy enemy = new Enemy();
            PrintFunctionParameters(enemy); 

        }

        private void Start()
        {
            // List mantýðýnýn primitif halini elle yazmak, tabii burada sabit elemanlý array oluyor: 

            MyList<string> myStrList = new MyList<string>();
            MyList<int> myIntList = new MyList<int>();

            myStrList.values[0] = "Cavs";
            myStrList.values[1] = "Nets";
            myStrList.values[2] = "Okc";

            for (int i = 0; i < myStrList.values.Length; i++)
            {
                if (myStrList.values[i] == null) continue;
                Debug.Log(myStrList.values[i]);
            }

            myIntList.values[0] = 1;
            myIntList.values[1] = 2;
            myIntList.values[2] = 3;
            myIntList.values[3] = 4;

            for (int i = 0; i < myIntList.values.Length; i++)
            {
                Debug.Log(myIntList.values[i]);
            }
        }


        public class BaseClass
        {

        }

        public class Player : BaseClass
        {
   
        }


        public class Enemy
        {
            
        }


    }


}
