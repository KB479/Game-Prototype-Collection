using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefValueType : MonoBehaviour
{
    public class MyClass
    {
        public int value;

        public MyClass(int value)
        {
            this.value = value;
        }
    }


    private void Start()
    {
        //ref type 
        MyClass first = new MyClass(7);
        MyClass second = first;
        second.value = 5;

        print(first.value); // çýktý 5

        //value type 
        int a = 7;
        int b = a;
        b = 5;
        print(a);


        // ref argüman
        int i = 10; 
        Debug.Log(Increment(i));

    }


    public  int Increment(int i)
    {
        return i + 1;
    }


}
