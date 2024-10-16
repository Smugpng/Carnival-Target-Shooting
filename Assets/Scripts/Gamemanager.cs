using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private static float Points;

    private void OnEnable()
    {
        EnemyPoint.onDeath += UpdatePoints;
    }

    public void UpdatePoints(float pointsGained)
    {
        Points += pointsGained;
    }
}
