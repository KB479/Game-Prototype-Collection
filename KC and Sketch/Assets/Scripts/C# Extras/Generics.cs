using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generics : MonoBehaviour
{

    public void Start()
    {
        int[] array = arrayMaker(5, 9);
        print("First Element: " + array[0] + " Second Element: " + array[1] + " Array Size: " + array.Length);

        string[] array2 = arrayMaker("bob", "dylan");
        print("First Element: " + array2[0] + " Second Element: " + array2[1] + " Array Size: " + array2.Length);

    }


    public T[] arrayMaker<T>(T x, T y)
    {
        return new T[] { x, y };
    }

}
