using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPoint : MonoBehaviour
{
    public UnityEvent<int> onDeathEvent;
    private GameManager gameManager;

    public float speed;
    public float size;
    
    [Header("Points I give")]
    public int point;

    public void OnDestroy()
    {
        onDeathEvent?.Invoke(point);
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        onDeathEvent.AddListener(gameManager.UpdatePoints);
        Invoke("OnDestroy", 5);
    }
}
