using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

    [SerializeField] private int maxEnergy = 3;
    [SerializeField] private int currentEnergy;

    public int Energy
    {
        get { return currentEnergy; }
    }

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    public void ResetEnergy()
    {
        currentEnergy = maxEnergy;
    }

    public void ReduceEnergy(int reduceAmount)
    {
        currentEnergy -= reduceAmount;
    }

}
