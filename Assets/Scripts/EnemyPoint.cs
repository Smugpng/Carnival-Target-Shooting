using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public delegate void OnDeath(float points);
    public static event OnDeath onDeath;

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
