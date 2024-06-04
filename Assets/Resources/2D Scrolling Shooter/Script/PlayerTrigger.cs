using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using static UnityEngine.UI.Image;

// 플레이어의 충돌 처리를 담당하는 스크립트.
public class PlayerTrigger : MonoBehaviour
{
    // 적 탄약의 태그.
    [SerializeField] private string enemyBulletTag;

    [SerializeField] private float currentHp = 0f;
    // 플레이어의 체력(Health Power).
    [SerializeField] private float MaxHp = 100f;
    [SerializeField] private UnityEngine.UI.Image hpBarImage;
    // 이벤트.
    public UnityEvent OnPlayerDamaged;
    public UnityEvent<Vector3> OnPlayerDead;

    private void Awake()
    {
        currentHp = MaxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 태그 비교.
        if (collision.CompareTag(enemyBulletTag))
        {
            // 적 탄약을 제거.
            Destroy(collision.gameObject);

            // 플레이어가 대미지를 입었다는 이벤트 발행.
            OnPlayerDamaged?.Invoke();

            // 대미지 처리.
            currentHp = currentHp - collision.GetComponent<BulletDamage>().Damage;
            currentHp = currentHp < 0f ? 0f : currentHp;

            if (hpBarImage != null)
            {
                // fillAmount 값은 퍼센티지를 계산해서 설정.
                hpBarImage.fillAmount = currentHp / MaxHp;
            }

            // 죽음 확인 및 이벤트 발행.
            if (currentHp == 0f)
            {
                // 이벤트 발행.
                OnPlayerDead?.Invoke(transform.position);

                // 플레이어 게임 오브젝트 제거.
                Destroy(gameObject);
            }
        }
    }
}