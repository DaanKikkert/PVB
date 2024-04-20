using System;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Events;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.WSA;

public class ClassInitializer : MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private RectTransform classVisual;
    [SerializeField] private CanvasGroup BG;
    private List<ClassBase> _classes = new List<ClassBase>();

    private void Awake()
    {

        string[] files = Directory.GetFiles(path, "*.asset", SearchOption.TopDirectoryOnly);
        for (int i = 0; i < files.Length; i++)
        {
            ClassBase currClassBase = (ClassBase)AssetDatabase.LoadAssetAtPath(files[i], typeof(ClassBase));
            _classes.Add(currClassBase);
        }
        SpawnClasses();

    }


    private void SpawnClasses()
    {

        for (int i = 0; i < _classes.Count; i++)
        {
            ClassBase currClass = _classes[i];
            RectTransform classItem = Instantiate(classVisual, transform);
            ClassvisualHolder visualSetter = classItem.gameObject.GetComponent<ClassvisualHolder>();
            if (visualSetter != null)
            {
                visualSetter.SetClassValues(currClass, BG);
            } 
                
        }


    }


}
