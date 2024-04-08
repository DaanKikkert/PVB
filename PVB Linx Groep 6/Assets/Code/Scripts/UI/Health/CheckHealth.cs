using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scripts.UI.Health
{
    public class CheckHealth : MonoBehaviour
    {
        [Header("Health Settings: ")]
        [SerializeField] private UniversalHealth getHealth;
        [SerializeField] private ResetGame getReset;
        
        public void CheckingHealth()
        {
            if (getHealth.GetCurrentHealth() <= 0)
            {
                if (gameObject.CompareTag("Castle"))
                    getReset.Resetting();
                Destroy(gameObject);
            }
        }
    }
}
