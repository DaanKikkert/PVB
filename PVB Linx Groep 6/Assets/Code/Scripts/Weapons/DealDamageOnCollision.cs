using UnityEngine;

namespace Code.Scripts.Weapons
{
    public class DealDamageOnCollision : MonoBehaviour
    {
        private int _damage = 1;
        private string tag;

        private void Start()
        {
            tag = this.gameObject.transform.parent.tag;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                if (tag == "Player")
                {
                    if (other.gameObject.CompareTag("Enemy"))
                        other.gameObject.GetComponent<UniversalHealth>().TakeDamage(_damage);
                    Debug.Log("Player hit");
                }

                if (tag == "Enemy")
                {
                    if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Castle"))
                        other.gameObject.GetComponent<UniversalHealth>().TakeDamage(_damage);
                    Debug.Log("Enemy hit");
                }
            }
        }

        public void SetDamage(int dmg)
        {
            _damage = dmg;
        }
    }
}

