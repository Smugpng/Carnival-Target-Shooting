using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Points { get; private set; }

    private void OnEnable()
    {
        
    }

    public void UpdatePoints(int pointsGained)
    {
        Points += pointsGained;
        Debug.Log(Points);
    }
}
