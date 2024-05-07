using System.IO;
using UnityEditor;
using UnityEngine;
using Weapons;

[CreateAssetMenu]
public class ClassBase : ScriptableObject
{
    public string classTitle;
    public string classDescription;
    public Sprite classIcon;
    public GameObject classModel;
    public int classBaseSpeed;
    public int classBaseHp;
    public Classes classType;
    public Weapon weapon;
}

