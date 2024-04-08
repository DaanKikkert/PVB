using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts
{
    public class ResetGame : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        
        public void Resetting() => SceneManager.LoadScene(sceneName);
    }
}
