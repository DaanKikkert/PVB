using System;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ClassInitializer : MonoBehaviour
{
    [SerializeField] private string path;
    [SerializeField] private RectTransform classVisual;
    [SerializeField] private CanvasGroup backGround;
    [SerializeField] private List<ClassBase> madeClasses = new List<ClassBase>();

    private void Awake()
    {
        var classes = Resources.LoadAll<ClassBase>(path);
        if (classes != null && madeClasses == null )
        {
            foreach (var curClass in classes)
            {
                madeClasses.Add(curClass);
            }
        }

        SpawnClasses();



    }


   

    private void SpawnClasses()
    {

        for (int i = 0; i < madeClasses.Count; i++)
        {
            ClassBase currClass = madeClasses[i];
            RectTransform classItem = Instantiate(classVisual, transform);
            ClassvisualHolder visualSetter = classItem.gameObject.GetComponent<ClassvisualHolder>();
            if (visualSetter != null)
            {
                visualSetter.SetClassValues(currClass, backGround);
            } 
                
        }


    }


}
