using UnityEngine;

namespace Code.Scripts.Weapons
{
    public class DealDamageOnCollision : MonoBehaviour
    {
        private int _damage = 1;
        private string tag;

        private void Start()
        {
            tag = this.gameObject.transform.tag;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (tag == "Player")
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    GameObject getObject = other.gameObject;
                    getObject.GetComponent<UniversalHealth>().TakeDamage(_damage);
                    if (getObject.GetComponent<UniversalHealth>() == null)
                    {
                        getObject.GetComponentInChildren<UniversalHealth>().TakeDamage(_damage);
                        if (getObject.GetComponentInChildren<UniversalHealth>() == null)
                            getObject.GetComponentInParent<UniversalHealth>().TakeDamage(_damage);
                    }
                }
            }

            if (tag == "Enemy")
            {
                if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Castle"))
                {
                    GameObject getObject = other.gameObject;
                    getObject.GetComponent<UniversalHealth>().TakeDamage(_damage);
                    if (getObject.GetComponent<UniversalHealth>() == null)
                    {
                        getObject.GetComponentInChildren<UniversalHealth>().TakeDamage(_damage);
                        if (getObject.GetComponentInChildren<UniversalHealth>() == null)
                            getObject.GetComponentInParent<UniversalHealth>().TakeDamage(_damage);
                    }
                }
            }
        }

        public void SetDamage(int dmg)
        {
            _damage = dmg;
        }
    }
}

