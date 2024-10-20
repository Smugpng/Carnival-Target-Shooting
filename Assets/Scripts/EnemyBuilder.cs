using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyAmount = 5;
    private float speed;
    private float size;
    private int point;
    private float yPosition;
    private float horizontalScreenLimit = 10.5f;

    enum speedOptions { slow, medium, fast };
    enum sizeOptions { average, medium, large };
    enum pointOptions { small, medium, large };
    enum rowLevelOptions { top, mid, bot };

    void Start()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            MakeEnemy(1);
        }
    }

    public void MakeEnemy(int points)
    {
        GetValues();
        float randomX = Random.Range(-horizontalScreenLimit, horizontalScreenLimit);
        Vector3 spawnPosition = new Vector3(randomX, yPosition, 0);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        newEnemy.GetComponent<EnemyPoint>().speed = speed;
        newEnemy.GetComponent<EnemyPoint>().size = size;
        newEnemy.GetComponent<EnemyPoint>().point = point;
        Debug.Log("Building enemy with speed: " + speed + ", size: " + size + ", point: " + point + ", Y position: " + yPosition);
    }


    void GetValues()
    {
        int speedNum = Random.Range(0, 3);
        int sizeNum = Random.Range(0, 3);
        int pointNum = Random.Range(0, 3);
        int rowNum = Random.Range(0, 3);

        switch ((speedOptions)speedNum)
        {
            case speedOptions.slow:
                speed = 2f;
                break;
            case speedOptions.medium:
                speed = 4f;
                break;
            case speedOptions.fast:
                speed = 6f;
                break;
        }

        switch ((sizeOptions)sizeNum)
        {
            case sizeOptions.average:
                size = 1f;
                break;
            case sizeOptions.medium:
                size = 1.5f;
                break;
            case sizeOptions.large:
                size = 2f;
                break;
        }

        switch ((pointOptions)pointNum)
        {
            case pointOptions.small:
                point = 10;
                break;
            case pointOptions.medium:
                point = 20;
                break;
            case pointOptions.large:
                point = 30;
                break;
        }

        switch ((rowLevelOptions)rowNum)
        {
            case rowLevelOptions.top:
                yPosition = 6f;
                break;
            case rowLevelOptions.mid:
                yPosition = 4f;
                break;
            case rowLevelOptions.bot:
                yPosition = 2f;
                break;
        }
    }
}
