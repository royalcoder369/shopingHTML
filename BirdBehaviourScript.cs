using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviourScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private Camera mainCamera;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        // Check if the bird goes out of the screen
        Vector3 birdPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (birdPosition.x < 0 || birdPosition.x > 1 || birdPosition.y < 0 || birdPosition.y > 1)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        logic.gameOver();
        birdIsAlive = false;
        Debug.Log("Game Over!");
    }
}
