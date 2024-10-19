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
    private float horizontalScreenLimit = 10.5f;
    private int direction = 1; // 1 for right, -1 for left

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

    private void Update()
    {
        MoveEnemy();
        SwapDirection();
    }

    void MoveEnemy()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
    }

    void SwapDirection()
    {
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
            direction *= -1;
    }
}
