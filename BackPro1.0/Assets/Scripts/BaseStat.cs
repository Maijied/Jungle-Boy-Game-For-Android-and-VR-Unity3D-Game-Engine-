using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{

    public List<StatBonus> BaseAdditives { get; set; }

	public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }
    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }
    public void RemoveStatBonus(StatBonus statBonus)
    {
		this.BaseAdditives.Remove(BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
    }
    public int GetCalculatedstatValue()
    {
		this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;

        return FinalValue;
    }

}
