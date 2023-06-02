using SurvivalProj.Behaviours;
using UnityEngine;

public enum EBulletType
{
    Normal, // 0
    SuperBullet //1
}

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private EBulletType bulletType;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(CharacterBehaviour.CHARACTER_LAYER_NAME))
        {
            collision.gameObject.GetComponent<CharacterBehaviour>().Character.AlterHP(-damage);
        }

        Destroy(gameObject);
    }
}