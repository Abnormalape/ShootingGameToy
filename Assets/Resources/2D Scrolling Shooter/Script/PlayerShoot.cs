using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float shootIntervale = 0.2f;
    [SerializeField] GameObject bullet;

    

    private float elapsedTime = 0f;

    //이벤트 : 대리자(delegate) : 유니티 이벤트나 C#이벤트로 작성해도 된다.
    public UnityEvent OnShoot;

    private void Awake()
    {
        InvokeRepeating("Shoot", 0f, shootIntervale);
    }

    private void Update()
    {

    }

    private void Shoot()
    {
        OnShoot.Invoke();
        Instantiate(bullet, transform.GetChild(0).transform.position, Quaternion.identity);
        Instantiate(bullet, transform.GetChild(1).transform.position, Quaternion.identity);
    }
}
