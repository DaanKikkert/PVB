using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class ResetGame : MonoBehaviour
    {
        [Header("Reset Scene Settings: ")] 
        [SerializeField] private string sceneName;
        
        public void Resetting() => SceneManager.LoadScene(sceneName);
    }
}
