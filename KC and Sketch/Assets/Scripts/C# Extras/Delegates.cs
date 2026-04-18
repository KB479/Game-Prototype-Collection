using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : MonoBehaviour
{

    public delegate void TestDelegate();
    public delegate bool BoolianDelegate(int i); 

    private TestDelegate testDelegateFunction;
    private BoolianDelegate testBoolDelegateFunction; 


    private void Start()
    {

        testDelegateFunction = new TestDelegate(MyTestDelegateFunction);
        //Kısaca testDelegateFunction = MyTestDelegateFunction; yazabiliriz.
        
        testDelegateFunction += MySecondTestDelegateFunction;
        testDelegateFunction += delegate () { Debug.Log("Anonymous method"); }; 
        testDelegateFunction += () => { Debug.Log("Lambda Expression"); };
        testDelegateFunction();

        testBoolDelegateFunction = MyThirdTestDelegateFunction;
        testBoolDelegateFunction += (int i) => { return i < 0; }; 
        print(testBoolDelegateFunction(2));

    }

    private void MyTestDelegateFunction()
    {
        Debug.Log("MyTestDelegateFunction");
    }

    private void MySecondTestDelegateFunction()
    {
        Debug.Log("MySecondTestDelegateFunction");
    }

    private bool MyThirdTestDelegateFunction(int i)
    {
        return i < 5; 
    }

}
