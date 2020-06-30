using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus : MonoBehaviour {

    public int BonusValue { get; set; }

    public StatBonus(int bonus)
    {
        this.BonusValue = BonusValue;
        Debug.Log("New state bonus initiated");
    }
}
