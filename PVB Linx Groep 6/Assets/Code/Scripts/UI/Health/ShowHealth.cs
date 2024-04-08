using Code.Scripts;
using Code.Scripts.UI.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ShowHealth : MonoBehaviour
    {

        [Header("Slider Settings: ")] 
        [SerializeField] private Slider getSlider;
        [SerializeField] private UniversalHealth getHealth;
        [SerializeField] private Text showHealth;

        private int _fixedHealth;
        
        // Start is called before the first frame update
        private void Awake()
        {
            getSlider.maxValue = getHealth.GetMaxHealth();
            _fixedHealth = getHealth.GetMaxHealth();
            showHealth.text = getHealth.GetMaxHealth() + "/" + getHealth.GetMaxHealth();
        }

        public void ShowsHealth()
        {
            getSlider.value = getHealth.GetCurrentHealth();
            showHealth.text = getHealth.GetCurrentHealth() + "/" + _fixedHealth + " HP";
        }
    }
}
