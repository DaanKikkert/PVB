using UnityEngine;

namespace Code.Scripts.Class_System
{
    public class ChangeClass : MonoBehaviour
    {

        private ClassChangerInScene _changerInScene;

        private void Start() => _changerInScene = FindObjectOfType<ClassChangerInScene>();
        
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _changerInScene.classCamera.SetActive(true);
                _changerInScene.classChangeUI.SetActive(true);
                
                Destroy(gameObject);
            }
        }
    }
}
