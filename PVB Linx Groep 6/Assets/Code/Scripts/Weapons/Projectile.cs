using Code.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime = 10f;

    [Tooltip("The tag of the one shooting projectile")]
    [SerializeField] private string attackerTag;

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
        if(attackerTag == "Player")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<UniversalHealth>().TakeDamage(baseDamage);
                Destroy(this.gameObject);
            }
        }

        if (attackerTag == "Enemy")
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Castle"))
            {
                other.gameObject.GetComponent<UniversalHealth>().TakeDamage(baseDamage);
                Destroy(this.gameObject);
            }
        }
    }

    public Projectile(int damage, string tag)
    {
        baseDamage = damage;
        attackerTag = tag;
    }
}
