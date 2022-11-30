namespace SurvivalProj.Behaviours
{
    using UnityEngine;

    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 10F;

        [SerializeField]
        private float runSpeed = 60F;

        private Character character;
        private Weapon weapon;

        private float xVal = 0F;
        private float yVal = 0F;

        private bool isRunning = false;

        // Start is called before the first frame update
        private void Start()
        {
            character = new Character("Hero", 10);
            weapon = new Weapon("PeyeSword");
        }

        // Update is called once per frame
        private void Update()
        {
            xVal = Input.GetAxis("Horizontal");
            yVal = Input.GetAxis("Vertical");

            if (xVal != 0F)
            {
                isRunning = Input.GetAxis("Fire2") > 0;
                
                transform.Translate(Vector3.right * (isRunning ? runSpeed : moveSpeed) * xVal * Time.deltaTime);
            }

            if (yVal != 0F)
            {
                isRunning = Input.GetAxis("Fire2") > 0;

                transform.Translate(Vector3.forward * (isRunning ? runSpeed : moveSpeed) * yVal * Time.deltaTime);
            }
        }
    }
}