using UnityEngine;

namespace Code.Scripts.Player
{
    
    public enum PlayerClass
    {
        Warrior,
        Archer,
        Mage
    }
    
    public class ClassManager : MonoBehaviour
    {
        public PlayerClass playerClass;
    }
}
