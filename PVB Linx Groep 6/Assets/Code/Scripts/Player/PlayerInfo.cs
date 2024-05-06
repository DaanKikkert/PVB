using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //We kunnen hier info geven over de speler. Een Info bron voor andere component?
    public Classes playerClass;

    public PlayerAttack attackScript;

    public Transform weaponSpawnPoint;
    //Int Level
    //String level



}
public enum Classes
{
    Knight,
    Archer,
    Mage
}
