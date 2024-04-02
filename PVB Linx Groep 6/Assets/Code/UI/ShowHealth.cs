using Code.Scripts.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ShowHealth : MonoBehaviour
    {

        [Header("Slider Settings: ")] 
        [SerializeField] private Slider getSlider;
        [SerializeField] private DepleteHealth getHealth;
        [SerializeField] private Text showHealth;

        private int _fixedHealth;
        
        // Start is called before the first frame update
        private void Awake()
        {
            getSlider.maxValue = getHealth.health;
            _fixedHealth = getHealth.health;
        }

        // Update is called once per frame
        private void Update()
        {
            getSlider.value = getHealth.health;
            showHealth.text = getHealth.health + "/" + _fixedHealth + " HP";
        }
    }
}
