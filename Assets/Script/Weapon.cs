using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory", order = 1)] //create menu option
public class Weapon : ScriptableObject {
    public GameObject weaponType;
    public GameObject bulletObject;
    public float fireinterval;
    public AudioClip audio;
    public int damage;
}
