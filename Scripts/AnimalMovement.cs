using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType
{
    Rabbit,
    chicken,
    BadAnimal
}

public class AnimalMovement : MonoBehaviour
{
    public AnimalType animalType;
    public float moveSpeed = 5f;
    private Vector3 currentDirection;
    private float timer;
    private float changeDirectionInterval;

    
    // Start is called before the first frame update
    void Start()
    {
        switch (animalType)
        {
            case AnimalType.Rabbit:
                changeDirectionInterval = 2f;
                break;
            case AnimalType.chicken:
                changeDirectionInterval = 3f;
                break;
            case AnimalType.BadAnimal:
                changeDirectionInterval = 5f;
                break;
        }
        currentDirection = Random.insideUnitSphere.normalized;
        currentDirection.y = 0;
        timer = changeDirectionInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            currentDirection = Random.insideUnitSphere.normalized;
            currentDirection.y = 0;
            timer = changeDirectionInterval;
        }
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }
}
