using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.Health
{
    public class Health : MonoBehaviour
    {
        [Header("Get Health: ")] 
        public int health;

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
