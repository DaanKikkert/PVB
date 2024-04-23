using Code.Scripts;
using Code.UI;
using TMPro;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

public class ClassvisualHolder : MonoBehaviour
{
    public Button button;
    
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    
    private ClassBase _thisClassBase;
    private CanvasGroup _backGround;
    
    public void SetClassValues(ClassBase classData, CanvasGroup BG)
    {
        _thisClassBase = classData;
        _backGround = BG;
        icon.sprite = _thisClassBase.classIcon;
        title.text = _thisClassBase.classTitle;
        description.text = _thisClassBase.classDescription;
        UnityEventTools.AddPersistentListener(button.onClick,LoadClassIntoPlayer);
    }


    public void LoadClassIntoPlayer()
    {
        WaveManager.instance.playerCount++;
        WaveManager.instance.CheckForNewWave();
        GameObject player = PlayerRespawnManager.instance.returnHostPlayer();
        player.GetComponent<PlayerInfo>().playerClass = _thisClassBase.classType;
        BasicMovement playerMovement = player.GetComponent<BasicMovement>();
        playerMovement.moveSpeed = _thisClassBase.classBaseSpeed;//Level bonus?
        playerMovement.enabled = true;
        UniversalHealth health = player.GetComponent<UniversalHealth>();
        health.SetMaxHealth(_thisClassBase.classBaseHp);//level bonus?
        player.transform.GetChild(0).GetComponent<MeshFilter>().mesh = _thisClassBase.classModel;
        StartCoroutine(FadeEffect.FadeOut(_backGround, 2));
        _backGround.gameObject.SetActive(false);
    }



}
