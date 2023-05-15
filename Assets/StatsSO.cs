using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject / Unit Stats")]
public class StatsSO : ScriptableObject
{
    public Dictionary<Stat, float> statsDict = new Dictionary<Stat, float>();
    
    public enum Stat
    {
        hitPoints,
        actionPoints,

        armorRating,
        blocking,
        criticalChance,

        strength,
        dexterity,
        intelligence,
        constitution,
        speed,
        perception,

        currentXP,
        nextLevelXPNeeded,
    }
}
