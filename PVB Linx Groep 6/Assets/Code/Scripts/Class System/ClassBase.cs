using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class ClassBase : ScriptableObject
{
    public string classTitle;
    public string classDescription;
    public Sprite classIcon;
    public Mesh classModel;
    public int classBaseSpeed;
    public int classBaseHp;
    public Classes classType;
}

