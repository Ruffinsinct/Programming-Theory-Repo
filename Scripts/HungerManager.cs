using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerManager : MonoBehaviour
{
    public Slider hungerSlider;
    public float maxHunger = 100f;
    public float hungerDecreaseRate = 5f;

    private float currentHunger;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        UpdateHungerUI();

        InvokeRepeating("DecreaseHunger", 1f, 1f);
    }

    void DecreaseHunger()
    {
        currentHunger -= hungerDecreaseRate;
        UpdateHungerUI();

        if (currentHunger <= 0)
        {
            Debug.Log("Game Over - Hunger Reached Zero");
        }
    }
    // Update is called once per frame
    void UpdateHungerUI()
    {
        hungerSlider.value = currentHunger;
    }

    public void AddPointsToHunger(float points)
    {
        currentHunger += points;

        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
        UpdateHungerUI();
    }
}
