﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon;

    void Start() => SelectWeapon();

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKey(KeyCode.Alpha1)) {
            selectedWeapon = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2) && transform.childCount >= 2 && Player.I.level >= 1) {
            selectedWeapon = 1;
        }

        if (Input.GetKey(KeyCode.Alpha3) && transform.childCount >= 3 && Player.I.level >= 2) {
            selectedWeapon = 2;
        }

        if (Input.GetKey(KeyCode.Alpha4) && transform.childCount >= 4 && Player.I.level >= 3) {
            selectedWeapon = 3;
        }

        if (Input.GetKey(KeyCode.Alpha5) && transform.childCount >= 5 && Player.I.level >= 4) {
            selectedWeapon = 4;
        }

        if (previousSelectedWeapon != selectedWeapon) {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform) {
            weapon.gameObject.SetActive(i == selectedWeapon);

            i++;
        }   
    }
}
