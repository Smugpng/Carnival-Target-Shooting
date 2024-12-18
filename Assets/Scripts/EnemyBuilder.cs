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
    private Color color;
    private int enemyCounter = 0;

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
        newEnemy.transform.localScale = Vector3.one * size;
        newEnemy.GetComponent<EnemyPoint>().speed = speed;
        newEnemy.GetComponent<EnemyPoint>().size = size;
        newEnemy.GetComponent<EnemyPoint>().point = point;
        newEnemy.GetComponent<Renderer>().material.color = color;
        newEnemy.name = GetEnemyNames();
        
        enemyCounter++;
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
                size = 0.8f;
                break;
            case sizeOptions.medium:
                size = 1f;
                break;
            case sizeOptions.large:
                size = 1.3f;
                break;
        }

        switch ((pointOptions)pointNum)
        {
            case pointOptions.small:
                point = 10;
                color = Color.red;
                break;
            case pointOptions.medium:
                point = 20;
                color = Color.green;
                break;
            case pointOptions.large:
                point = 30;
                color = Color.yellow;
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

    string GetEnemyNames()
    {
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Target");
        HashSet<int> existingIndices = new HashSet<int>();

        foreach (GameObject enemy in existingEnemies)
        {
            if (enemy.name.StartsWith("enemy") && int.TryParse(enemy.name.Substring(5), out int index))
                existingIndices.Add(index);
        }
        int newIndex = 0;
        while (existingIndices.Contains(newIndex))
        {
            newIndex++;
        }
        return "enemy" + newIndex;
    }
}
