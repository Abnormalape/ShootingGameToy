using System;
using UnityEngine;

class BulletDamage : MonoBehaviour
{
    [SerializeField] private float damgae = 10f;

    public float Damage
    {
        get
        {
            return damgae;
        }
    }
}
