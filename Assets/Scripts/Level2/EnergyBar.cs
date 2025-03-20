using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public float maxEnergy = 25.0f;
    public float currentEnergy;
    public Slider slider;
    public GameObject wall;

    void Start()
    {
        currentEnergy = maxEnergy;
        slider.maxValue = maxEnergy;
        slider.value = currentEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (wall.activeSelf == true)
        {
            currentEnergy -= Time.deltaTime;
            slider.value = currentEnergy;
            if (currentEnergy <= 0.0f)
            {
                DestroyWall();
            }
        }
    }
    void DestroyWall()
    {
        wall.SetActive(false);
        GameManager.Instance.StartHint("يبدو أن جدار الحماية بحاجة إلى تحديثه!");
    }
    public void addEnergy(float _addEnergy)
    {
        //sound
        SoundManager.PlaySound(SoundType.Devices);

        currentEnergy += _addEnergy;

        if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;

        wall.SetActive(true);
    }
    public void loseEnergy(float _loseEnergy)
    {
        //sound
        SoundManager.PlaySound(SoundType.Damage);
        currentEnergy -= _loseEnergy;
    }
}
