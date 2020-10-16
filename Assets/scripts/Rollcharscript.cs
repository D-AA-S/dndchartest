using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollcharscript : MonoBehaviour
{
    int d6Total = 3;
    int d4Total = 3;
    List<float> d4roll;
    List<float> d6roll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float statroller()
    {
        float total;
        for (int i = 0; i < d6Total; i++)
        {
            d6roll.Add(Random.Range(1, 6));
        }
        for (int i = 0; i < d4Total; i++)
        {
            d6roll.Add(Random.Range(1, 4));
        }
        d6roll.Sort();
        d4roll.Sort();
        total = d6roll[1] + d6roll[2] + d4roll[1] + d4roll[2];
        return total;
    }
}
