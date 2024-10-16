using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject[] bulletPool;
    private int currentBullet = 0;
    private Rigidbody rb;
    private Vector2 moveInput;

    private float moveSpeed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
        CheckIfInBounds();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            canShoot = false;
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            StartCoroutine("Cooldown");
            bulletPool[currentBullet].GetComponent<Bullet>().enabled = true;
            bulletPool[currentBullet].transform.position = bulletPosition;
            currentBullet++;
        }

        if(currentBullet >=  bulletPool.Length)
            currentBullet = 0;
    }

    void CheckIfInBounds()
    {
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit) //horizontal bounds checks
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }

        else if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit) //vertical bounds checks
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }
}