using SurvivalProj.Behaviours;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private int addHealth = 2;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterBehaviour character = other.GetComponent<CharacterBehaviour>();
        
        if (character != null)
        {
            character.Character.AlterHP(addHealth);
            print(character.Character.GetHP());
            
            Destroy(gameObject);
        }
    }
}