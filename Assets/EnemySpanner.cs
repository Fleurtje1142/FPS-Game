using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanner : MonoBehaviour
{
    public GameObject OGEnemy;
    public int enemyMax;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyMax; i++)
        {
            GameObject enemy = Instantiate(OGEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
