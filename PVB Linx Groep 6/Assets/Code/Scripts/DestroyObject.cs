using UnityEngine;

namespace Code.Scripts
{
    public class DestroyObject : MonoBehaviour
    {
        public void DestroyThisObject() => Destroy(gameObject);
    }
}
