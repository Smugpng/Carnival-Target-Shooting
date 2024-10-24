using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Points;

    public TMP_Text text;
    public void UpdatePoints(int pointsGained) //Gets called when a enemy dies and updates the text
    {
        Points += pointsGained;
        string points = Points.ToString();
        text.SetText(points);
        Debug.Log(Points);
    }

    public void SaveMyStats()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadMyStats()
    {
        PlayerData data = SaveSystem.LoadStats();
        Points = data.totalPoints;
        string points = Points.ToString();
        text.SetText(points);
        Debug.Log(Points);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Saving");
            SaveMyStats();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadMyStats();
        }
    }

}
