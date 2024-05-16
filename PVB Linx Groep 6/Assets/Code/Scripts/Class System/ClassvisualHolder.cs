using Code.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClassvisualHolder : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    public Button button;
    private ClassBase thisClassBase;
    CanvasGroup backGround;
    public void SetClassValues(ClassBase classData, CanvasGroup BG)
    {
        thisClassBase = classData;
        backGround = BG;
        icon.sprite = thisClassBase.classIcon;
        title.text = thisClassBase.classTitle;
        description.text = thisClassBase.classDescription;
        UnityEventTools.AddPersistentListener(button.onClick,LoadClassIntoPlayer);
    }


    public void LoadClassIntoPlayer()
    {
        WaveManager.instance.playerCount++;
        WaveManager.instance.CheckForNewWave();
        GameObject player = PlayerRespawnManager.instance.returnHostPlayer();
        player.GetComponent<PlayerInfo>().playerClass = thisClassBase.classType;
        BasicMovement playerMovement = player.GetComponent<BasicMovement>();
        playerMovement.moveSpeed = thisClassBase.classBaseSpeed;//Level bonus?
        playerMovement.enabled = true;
        player.GetComponent<UniversalHealth>().SetMaxHealth(thisClassBase.classBaseHp);//level bonus?
        player.transform.GetChild(0).GetComponent<MeshFilter>().mesh = thisClassBase.classModel;
        StartCoroutine(FadeEffect.FadeOut(backGround, 2));
        backGround.gameObject.SetActive(false);
    }



}
