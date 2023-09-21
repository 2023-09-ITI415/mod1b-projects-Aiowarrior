using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where the AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection;

    // Rate at which Apples will be instantiated
    private float secondsBetweenAppleDrop;
    

    void Start()
    {
      
      // Dropping apples every second
      Invoke( "DropApple", 2f );

    }


    void DropApple()
    {
        secondsBetweenAppleDrop = Random.Range(0.1f, 3.0f);
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
        Invoke( "DropApple", secondsBetweenAppleDrop );
    }

    void Update()
    {
        // Basic Movement

        Vector3 pos = transform.position; // b

        pos.x += speed * Time.deltaTime; // c

        transform.position = pos; // d

        // Changing Direction
        if ( pos.x < -leftAndRightEdge ) { // a
            speed = Mathf.Abs(speed); // Move right // b
        } else if ( pos.x > leftAndRightEdge ) { // c
            speed = -Mathf.Abs(speed); // move left //c
        }

    }

    void FixedUpdate()
    {
        // Changing Direction Randomly is now time-based because of
        if ( Random.value < chanceToChangeDirection ) {
            speed *= -1; // Change direction
        }
    }
}


