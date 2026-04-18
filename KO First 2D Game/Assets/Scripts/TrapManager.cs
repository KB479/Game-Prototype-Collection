using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{

    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;

    public Vector2 areaSize = new Vector2(16, 6);

    public int trap1Num = 6;
    public int trap2Num = 10;
    public int trap3Num = 1;


    public void Start()
    {

        CrateTrap1();
        CrateTrap2();
        CrateTrap3();

    }

    void CrateTrap1()
    {
        
        for (int i = 0; i < trap1Num; i++)
        {

            //float deðer veren random range trap1 örneðindeki gibi int yapýlabilir, þimdilik gerek yok

            int randomX = Mathf.FloorToInt(Random.Range(-areaSize.x / 2, areaSize.x / 2));
            int randomY = Mathf.FloorToInt(Random.Range(-areaSize.y / 2, areaSize.y / 2));

            Vector2 randomPosition = new Vector2(randomX, randomY);

            Instantiate(trap1, randomPosition, Quaternion.identity);
        }
    }
    
    void CrateTrap2()
    {

        for (int i = 0; i < trap2Num; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-areaSize.x / 2, areaSize.x / 2),
                                                 Random.Range(-areaSize.y / 2, areaSize.y / 2));


            Instantiate(trap2, randomPosition, Quaternion.identity);
        }


    }

    void CrateTrap3()
    {

        for (int i = 0; i < trap3Num; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(-areaSize.x / 2, areaSize.x / 2),
                                                 Random.Range(-areaSize.y / 2, areaSize.y / 2));


            Instantiate(trap3, randomPosition, Quaternion.identity);
        }
    }


}
