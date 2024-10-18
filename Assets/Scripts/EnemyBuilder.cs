using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float speed;
    private float size;
    private int point;

    enum speedOptions {slow, medium, fast};
    enum sizeOptions {average, medium, large};
    enum pointOptions {small, medium, large};

    void Start()
    {
        MakeEnemy();
    }

    void MakeEnemy()
    {
        //speedVal = Random.Range(0, 2);  
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.GetComponent<EnemyPoint>().speed = speed;
    }
}
