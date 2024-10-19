using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Points { get; private set; }

    public TMP_Text text;
    public void UpdatePoints(int pointsGained)
    {
        Points += pointsGained;
        string points = Points.ToString();
        text.SetText(points);
        Debug.Log(Points);
    }
}
