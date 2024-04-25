using UnityEngine;

namespace Code.Scripts.Player
{
    
    public enum PlayerClass
    {
        Warrior,
        Ranger,
        Mage
    }
    
    public class ClassManager : MonoBehaviour
    {
        public PlayerClass playerClass;
    }
}
