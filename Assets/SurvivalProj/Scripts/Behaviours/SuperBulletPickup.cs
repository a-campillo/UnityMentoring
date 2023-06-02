using SurvivalProj.Behaviours;
using UnityEngine;

public class SuperBulletPickup : Pickup
{
    [SerializeField]
    private int ammo = 2;

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer(CharacterBehaviour.CHARACTER_LAYER_NAME)))
        {
            collision.gameObject.GetComponent<CharacterBehaviour>().EnableSuperBullet(ammo);
            base.OnCollisionEnter(collision);
        }
    }
}