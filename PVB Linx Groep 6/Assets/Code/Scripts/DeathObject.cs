using UnityEngine;

namespace Code.Scripts
{
    public class DeathObject : MonoBehaviour
    {
        public void DestroyObject() => Destroy(gameObject);
    }
}
