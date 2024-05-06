using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class EmoteHandler : MonoBehaviour
{

    [SerializeField] private GameObject[] Emotes;
    private bool _isEmoting;
    [SerializeField]private float delayBetweenEmotes;
    [SerializeField] private float emoteHeight;
    private int _emoteID;

    public UnityEvent onEmote;
    public int getEmoteID()
    {
        return _emoteID;
    }
    public float GetemoteHeight()
    {
        return emoteHeight;
    }
    public float GetdelayBetweenEmotes()
    {
        return delayBetweenEmotes;
    }
    public GameObject[] getPlayerEmotesList() 
    {        
        return Emotes;
    }
    private IEnumerator EmoteCreator(int EmoteID)
    {
        if (!_isEmoting)
        {
            _emoteID = EmoteID;
            _isEmoting = true;
            GameObject emote = Instantiate(Emotes[EmoteID], transform);
            emote.transform.localPosition = new Vector3(0, emoteHeight, 0);
            if (onEmote != null)
                onEmote.Invoke();
            yield return new WaitForSeconds(delayBetweenEmotes);
            Destroy(emote);
            _isEmoting = false;
        }
    }

    private void HandleInputEmotes()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            StartCoroutine(EmoteCreator(0));
        if (Input.GetKeyUp(KeyCode.Alpha2))
            StartCoroutine(EmoteCreator(1));
        if (Input.GetKeyUp(KeyCode.Alpha3))
            StartCoroutine(EmoteCreator(2));
        if (Input.GetKeyUp(KeyCode.Alpha4))
            StartCoroutine(EmoteCreator(3));

    }

    private void Update()
    {
        HandleInputEmotes();
    }
}
