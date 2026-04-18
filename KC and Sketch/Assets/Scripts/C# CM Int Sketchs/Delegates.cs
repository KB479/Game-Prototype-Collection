using System;
using UnityEngine;


namespace Lecture
{
        public class Delegates : MonoBehaviour
        {

            private delegate void MyFirstDelegate();
            private MyFirstDelegate myFirstDelegate; 

            private delegate bool MySecondDelegate(int x);

            private Action action;
            private Func<int, bool> func;


            private void Start()
            {
                myFirstDelegate = SayHello;
                myFirstDelegate += SayGoodbye;
                myFirstDelegate();

                MySecondDelegate mySecondDelegate = IsAllowed;
                Debug.Log(mySecondDelegate(16));

                action = SayHello;
                action();

                //çalýþmaz imzalar uyuþmuyor
                //action += IsAllowed;  
        
                action += () =>
                {
                    Debug.Log("Anonim Fonksiyon!");
                };
                action(); 

                func = IsAllowed;
                print(func(20));

                func += (int x) =>
                {
                    if (x == 17)  return true;
                    else return false;
                };

                print(func(17)); 
            }


            private void SayHello()
            {
                Debug.Log("Hello World!"); 
            }

            private void SayGoodbye()
            {
                Debug.Log("Goodbye World!"); 
            }

    
            private bool IsAllowed(int age)
            {
                if (age < 18) return false;
                else return true;
            }



        }

}

