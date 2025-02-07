using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    float targetNum = 30.0f;
    public Slider slider;
    public GameObject wall;

    void Start()
    {
        slider.maxValue = targetNum;
        slider.value = targetNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (wall.activeSelf == true)
        {
            targetNum -= Time.deltaTime;
            slider.value = targetNum;
            if (targetNum <= 0.0f)
            {
                DestroyWall();
            }
        }
    }
    void DestroyWall()
    {

        wall.SetActive(false);

    }
    public void addEnergy(float _addEnergy)
    {
        targetNum += _addEnergy;
        wall.SetActive(true);
    }
    public void loseEnergy(float _loseEnergy)
    {
        targetNum -= _loseEnergy;
    }
}
