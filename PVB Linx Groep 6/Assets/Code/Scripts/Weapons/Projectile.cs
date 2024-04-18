using Code.Scripts;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime = 10f;

    [Tooltip("The tag of the one shooting projectile")]
    [SerializeField] private string _attackerTag;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(_attackerTag == "Player")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                GameObject getObject = other.gameObject;
                getObject.GetComponent<UniversalHealth>().TakeDamage(baseDamage);
                Destroy(gameObject);
            }
        }

        if (_attackerTag == "Enemy")
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Castle"))
            {
                GameObject getObject = other.gameObject;
                getObject.GetComponent<UniversalHealth>().TakeDamage(baseDamage);
                Destroy(gameObject);
            }
        }
    }

    public Projectile(int damage, string tag)
    {
        baseDamage = damage;
        _attackerTag = tag;
    }
}
