namespace SurvivalProj.Behaviours
{
    using UnityEngine;

    public class CharacterBehaviour : MonoBehaviour
    {
        public static readonly string CHARACTER_LAYER_NAME = "Player";

        [Header("Movement")]
        [SerializeField]
        private float moveSpeed = 10F;

        [SerializeField]
        private float runSpeed = 60F;

        [Header("Rotation")]
        [SerializeField]
        private float rotationSpeed = 20F;

        [SerializeField]
        private float mouseRotationDeadZone = 10F;

        [Header("Shoot")]
        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private GameObject superBulletPrefab;

        [SerializeField]
        private float shootForce = 150F;

        [SerializeField]
        private Transform spawnPosition;

        private Character character;
        private Weapon weapon;

        private float yVal = 0F;

        private bool isRunning = false;

        private new Rigidbody rigidbody;

        private Ray ray;
        private RaycastHit hit;

        private Vector3 screenCenter;

        private bool superBulletEnabled;
        private int remainingSuperBullet;

        public Character Character
        { get { return character; } }

        public void EnableSuperBullet(int ammo)
        {
            superBulletEnabled = true;
            remainingSuperBullet += ammo;
        }

        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;

            character = new Character("Hero", 10);
            weapon = new Weapon("PeyeSword");

            screenCenter = new Vector3(Screen.width / 2F, Screen.height / 2F);

            this.rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void Update()
        {
            ProcessRotation();
            ProcessBulletShoot(superBulletEnabled);
        }

        private void ProcessBulletShoot()
        {
            if (bulletPrefab != null)// && spawnPosition != null && Input.GetButtonDown("Fire1"))
            {
                //Rigidbody bulletClone = Instantiate<Rigidbody>(bulletPrefab, spawnPosition.position, spawnPosition.rotation); // Instantiates bullet
                //bulletClone.AddForce(transform.forward * shootForce, ForceMode.VelocityChange);

                //GameObject cloneGO = Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation); // Clone GO;
                //Rigidbody rb = cloneGO.GetComponent<Rigidbody>();
                //rb.AddForce(transform.forward * shootForce, ForceMode.VelocityChange); // shoots bullet

                Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation) // Clone GO
                    .GetComponent<Rigidbody>() // Retrieves Rigidbody component
                    .AddForce(transform.forward * shootForce, ForceMode.VelocityChange); // shoots bullet
            }
            else if (superBulletPrefab != null)// && spawnPosition != null && Input.GetButtonDown("Fire2"))
            {
                Instantiate(superBulletPrefab, (spawnPosition.position + spawnPosition.forward * 0.5F), spawnPosition.rotation) // Clone GO
                    .GetComponent<Rigidbody>() // Retrieves Rigidbody component
                    .AddForce(transform.forward * shootForce, ForceMode.VelocityChange); // shoots bullet
            }
        }

        private void ProcessBulletShoot(bool useSuperBullet)
        {
            if (spawnPosition != null && Input.GetButtonDown("Fire1"))
            {
                if (useSuperBullet)
                {
                    Instantiate(superBulletPrefab, (spawnPosition.position + spawnPosition.forward * 0.5F), spawnPosition.rotation) // Clone GO
                        .GetComponent<Rigidbody>() // Retrieves Rigidbody component
                        .AddForce(transform.forward * shootForce, ForceMode.VelocityChange); // shoots bullet

                    remainingSuperBullet -= 1;

                    if (remainingSuperBullet < 1)
                    {
                        remainingSuperBullet = 0;
                        superBulletEnabled = false;
                    }
                }
                else
                {
                    ProcessBulletShoot();
                } 
            }
        }

        private void ProcessMovement()
        {
            yVal = Input.GetAxis("Vertical");

            if (yVal != 0F)
            {
                isRunning = Input.GetAxis("Run") > 0;

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

        private void FixedUpdate()
        {
            ProcessMovementWithPhysics();
        }

        private void ProcessMovementWithPhysics()
        {
            yVal = Input.GetAxis("Vertical");

            if (yVal != 0)
            {
                isRunning = Input.GetAxis("Fire2") > 0;
                rigidbody.MovePosition(transform.position + transform.forward * (isRunning ? runSpeed : moveSpeed) * yVal * Time.fixedDeltaTime);
            }
        }

        private void ProcessRotation()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point); // Look at the point
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            }
        }
    }
}