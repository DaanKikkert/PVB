using System;
using System.Collections;
using UnityEngine;

public class EmoteRespone : MonoBehaviour
{
    [SerializeField] private float delayBetweenLeaving;
    [SerializeField] private float responseTime;
    private EmoteHandler _playerInput;
    private GameObject _emote;
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            _playerInput = player.gameObject.GetComponent<EmoteHandler>();
            _playerInput.onEmote.AddListener(emoteResponse);
        }
    }

    private void Update()
    {
        if (_emote != null && _playerInput != null)
            _emote.transform.position = new Vector3(transform.position.x, _playerInput.GetemoteHeight(), transform.position.z);
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
            StartCoroutine(delayRemovePlayer());

    }
    private void emoteResponse()
    {
       StartCoroutine(EmoteCreator(_playerInput));
    }

    private IEnumerator delayRemovePlayer()
    {
        yield return new WaitForSeconds(delayBetweenLeaving);
        if (_playerInput!= null)
            _playerInput.onEmote.RemoveListener(emoteResponse); 
        _playerInput = null;
    }

    //Mogelijk Override doen? Idk hoe het goed werkt dus ik doe voor nu zo
    private IEnumerator EmoteCreator(EmoteHandler playerInput)
    {
        yield return new WaitForSeconds(responseTime);
        _emote = Instantiate(playerInput.getPlayerEmotesList()[playerInput.getEmoteID()]);
        _emote.transform.transform.localScale = new Vector3(.1f,.1f,.1f);
        _emote.transform.position = new Vector3(0, playerInput.GetemoteHeight(), 0);
        yield return new WaitForSeconds(playerInput.GetdelayBetweenEmotes());
        Destroy(_emote);
        _emote = null;
    }
}
