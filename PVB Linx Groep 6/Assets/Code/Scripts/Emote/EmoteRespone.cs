using System;
using System.Collections;
using UnityEngine;

public class EmoteRespone : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float delayBetweenLeaving;
    [SerializeField] private float responseTime;
    private EmoteHandler _playerInput;
    private GameObject _emote;
    
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            if (player.gameObject.layer == playerLayer)
            {
                Debug.Log(player.gameObject.name);
                _playerInput = player.gameObject.GetComponent<EmoteHandler>();
                if (_playerInput.onEmote != null && _playerInput != null)
                    _playerInput.onEmote.AddListener(emoteResponse);
            }
                
            
        }
    }

    private void Awake()
    {
        GameObject player =  PlayerRespawnManager.instance.GetPlayerHolder().GetChild(0).gameObject;
        _playerInput = player.gameObject.GetComponent<EmoteHandler>();
        if (_playerInput.onEmote != null && _playerInput != null)
            _playerInput.onEmote.AddListener(emoteResponse);
    }

    private void Update()
    {
        if (_emote != null && _playerInput != null)
            _emote.transform.position = new Vector3(transform.position.x, _playerInput.GetemoteHeight() *2, transform.position.z);
    }
    private void emoteResponse()
    {
       StartCoroutine(EmoteCreator(_playerInput));
    }

    //Mogelijk Override doen? Idk hoe het goed werkt dus ik doe voor nu zo
    private IEnumerator EmoteCreator(EmoteHandler playerInput)
    {
        yield return new WaitForSeconds(responseTime);
        _emote = Instantiate(playerInput.getPlayerEmotesList()[playerInput.getEmoteID()]);
        _emote.transform.transform.localScale = new Vector3(.2f,.2f,.2f);
        _emote.transform.position = new Vector3(0, playerInput.GetemoteHeight(), 0);
        yield return new WaitForSeconds(playerInput.GetdelayBetweenEmotes());
        Destroy(_emote);
        _emote = null;
    }
}
