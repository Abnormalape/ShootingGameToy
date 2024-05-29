using System;
using UnityEngine;
using UnityEngine.Events;

class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private string playerBulletTag;

    float hp = 100f;

    public UnityEvent OnDamaged;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            OnDamaged?.Invoke();
            hp = hp - collision.GetComponent<BulletDamage>().Damage;
            hp = hp < 0f ? 0f : hp;
            if(hp == 0f)
            {
                Instantiate(Resources.Load($"2D Scrolling Shooter/Prefabs/Explosion") as GameObject, this.transform.position, Quaternion.identity);


                Destroy(gameObject);
            }
        }
    }
}
