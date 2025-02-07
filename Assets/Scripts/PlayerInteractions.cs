using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    public EnergyBar energyBar;

    public void addEnergyToEnergyBarScript(float energy)
    {
        energyBar.addEnergy(energy);
    }
    public void loseHeart()
    {
        GameManager.Instance.LoseHeart();
    }

}
