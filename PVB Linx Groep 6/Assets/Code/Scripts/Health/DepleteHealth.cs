using UnityEngine;

namespace Code.Scripts.Health
{
    public class DepleteHealth : MonoBehaviour
    {

        [Header("Get Health: ")] 
        public Health getHealth;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        private void Update()
        {
            if (getHealth.health <= 0)
                Destroy(gameObject);
        }
    }
}
