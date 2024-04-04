using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Health
{
    public class DepleteHealth : MonoBehaviour
    {
        [Header("Get Health: ")] 
        public int health;

        [Header("Game Over Settings: ")] 
        [SerializeField] private GameObject getGameOver;


        public void CheckHealth()
        {
            if (health <= 0)
            {
                if (gameObject.CompareTag("Castle"))
                    SceneManager.LoadScene("Castle");
                Destroy(gameObject);
            }
        }
    }
}
