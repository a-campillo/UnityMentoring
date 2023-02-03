using SurvivalProj;
using SurvivalProj.Behaviours;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LavaFloor : MonoBehaviour
{
    [SerializeField]
    private int dmgValue = 2;

    private Character targetCharacter;

    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterBehaviour character = other.GetComponent<CharacterBehaviour>();

        if (character != null)
        {
            targetCharacter = character.Character;
            InvokeRepeating("ApplyDamage", 0F, 1F);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("ApplyDamage");
        targetCharacter = null;
    }

    private void ApplyDamage()
    {
        if (targetCharacter != null)
        {
            targetCharacter.AlterHP(-dmgValue);
            print(targetCharacter.GetHP());
        }
    }
}