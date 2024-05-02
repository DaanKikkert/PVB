using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteRespone : MonoBehaviour
{
    [SerializeField] private float responseTime;
    private EmoteHandler _playerInput;
    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("Something has enterd");
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Player has enterd");
            _playerInput = player.gameObject.GetComponent<EmoteHandler>();
            if (_playerInput == null)
                Debug.Log("Is null How?");
            _playerInput.onEmote.AddListener(emoteResponse);
        }
    }



    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            _playerInput.onEmote.RemoveListener(emoteResponse);
            _playerInput = null;
        }

    }
    private void emoteResponse()
    {
       StartCoroutine(EmoteCreator(_playerInput));
    }


    //Mogelijk Override doen? Idk hoe het goed werkt dus ik doe voor nu zo
    private IEnumerator EmoteCreator(EmoteHandler playerInput)
    {

        yield return new WaitForSeconds(responseTime);
        GameObject emote = Instantiate(playerInput.getPlayerEmotesList()[playerInput.getEmoteID()], transform);
        emote.transform.localPosition = new Vector3(0, playerInput.GetemoteHeight(), 0);
        yield return new WaitForSeconds(playerInput.GetdelayBetweenEmotes());
        Destroy(emote);

    }
}
