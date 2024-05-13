using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PingSystem : MonoBehaviour
{
    public static UnityEvent onPing = new UnityEvent();
    private static Vector3 _lastMousePosition;
    private bool _hasPinged;
    [SerializeField] private float delayBetweenPings;
    [SerializeField] private GameObject[] pingPrefabs;
    [SerializeField] private GameObject background;
    [SerializeField] private float heightOffset;

    public void Start()
    {
        background.SetActive(false);
    }
    public static Vector3 LastMousePosition()
    {
        return _lastMousePosition;
    }

    public IEnumerator DestroyPingAfterTime(int index)
    {

        if (!_hasPinged)
        {
            _hasPinged = true;
            GameObject ping = Instantiate(pingPrefabs[index],new Vector3(_lastMousePosition.x, heightOffset, _lastMousePosition.z) , Quaternion.identity);
            if (onPing != null)
                onPing.Invoke();
            yield return new WaitForSeconds(delayBetweenPings);
            Destroy(ping);
            _hasPinged = false;
        }
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
            return (hitInfo.point);
        else
            return (Vector3.zero);
    }
    public void SetPing(int pingIndex)
    {
       
        StartCoroutine(DestroyPingAfterTime(pingIndex));
        background.SetActive(false);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !background.active)
        {
            _lastMousePosition = GetMousePosition();
            background.SetActive(true);
        }    
            
        else if (Input.GetKeyDown(KeyCode.E) && background.active)
            background.SetActive(false);
    }
}
