using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPoint : MonoBehaviour
{
    public delegate void OnDeath(float points);
    public static event OnDeath onDeath;

    public float speed;
    public float size;
    public int point;

    [Header("Points I give")]
    public float points;

    public void OnDestroy()
    {
        onDeath?.Invoke(points);
    }

    private void Start()
    {
        Invoke("OnDestroy", 5);
    }
}
