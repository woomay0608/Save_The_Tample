using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equip", menuName = "Stage/Equip")]
public class EquipSo : ScriptableObject
{
    public EquipType type;
    public float Value;
    public string Name;


}
