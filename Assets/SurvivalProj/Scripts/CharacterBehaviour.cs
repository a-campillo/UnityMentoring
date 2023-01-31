namespace SurvivalProj.Behaviours
{
    using UnityEngine;

    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 10F;

        [SerializeField]
        private float runSpeed = 60F;

        [SerializeField]
        private float rotationSpeed = 20F;

        private Character character;
        private Weapon weapon;

        private float xVal = 0F;
        private float yVal = 0F;

        private Vector2 rotValue;
        private float currentMousePosition = 0F;
        private bool facingForward = true;

        private bool isRunning = false;

        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;

            character = new Character("Hero", 10);
            weapon = new Weapon("PeyeSword");
        }

        // Update is called once per frame
        private void Update()
        {
            ProcessMovement();

            ProcessRotation();
        }

        private void ProcessMovement()
        {
            xVal = Input.GetAxis("Horizontal");
            yVal = Input.GetAxis("Vertical");

            if (yVal != 0F)
            {
                isRunning = Input.GetAxis("Fire2") > 0;

                if (isRunning)
                {
                    transform.Translate(Vector3.forward * runSpeed * yVal * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.forward * moveSpeed * yVal * Time.deltaTime);
                }
            }
        }

        private void ProcessRotation()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point); // Look at the point
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            }
        }
    }
}