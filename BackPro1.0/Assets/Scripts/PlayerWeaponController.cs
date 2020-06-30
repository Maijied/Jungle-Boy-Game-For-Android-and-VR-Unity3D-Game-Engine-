﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeaponController : MonoBehaviour {

	public GameObject playerHand;
	public GameObject Equippedweapon {
		get;
		set;
	}
	IWeapon equippedWeapon;
	CharacterStats characterStats;
	void Start(){
		characterStats = GetComponent<CharacterStats> ();
	}

	public void Equipweapon(Item itemToEquip){
		if (Equippedweapon != null) {
			characterStats.RemoveStatBonus (Equippedweapon.GetComponent<IWeapon>().Stats);
			Destroy (playerHand.transform.GetChild (0).gameObject);
		}

		Equippedweapon = (GameObject)Instantiate (Resources.Load<GameObject> ("Weapons/" + itemToEquip.ObjectSlug), 
			playerHand.transform.position, playerHand.transform.rotation);

		equippedWeapon =Equippedweapon.GetComponent<IWeapon> ();
		equippedWeapon.Stats = itemToEquip.Stats;
		Equippedweapon.transform.SetParent (playerHand.transform);
		characterStats.AddStatBonus (itemToEquip.Stats);
		Debug.Log (equippedWeapon.Stats[0].GetCalculatedstatValue());
	}
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.X))

            PerformWeaponAttack();

        if (Input.GetKeyDown (KeyCode.Z))
            PerformWeaponSpecialAttack();
    }

	public void PerformWeaponAttack()
    {
		equippedWeapon.PerformAttack();
	}
    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }
}
