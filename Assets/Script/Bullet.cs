using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    enum Rotation { Right, Left}
    
    public float bulletLife = 1f;
    public float bulletRotation = 0f;
    public float speed = 1f;

    private Vector2 spawnPoint;
    private float timer = 0f;

    [SerializeField] private Rotation rotation;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if(timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer)
    {
        float x, y;

        if (rotation == Rotation.Right)
        {
            x = timer * speed * transform.right.x;
            y = timer * speed * transform.right.y;
        }
        else
        {
            x = timer * speed * -transform.right.x;
            y = timer * speed * -transform.right.y;
        }

        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
}
