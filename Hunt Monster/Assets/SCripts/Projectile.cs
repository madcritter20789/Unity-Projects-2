using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public int damage;

    public GameObject soundObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Instantiate(soundObject, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector2.up*speed*Time.deltaTime);   
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }if (other.tag == "boss")
        {
            other.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }


}
