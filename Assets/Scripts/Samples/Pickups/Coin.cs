using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum ECoinType
    {
        Red,
        Green,
        Blue
    }

    public ECoinType coinType;

    public float rotationSpeed = 10F;

    private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();

        if (collider != null)
        {
            collider.isTrigger = true;

            Material material = GetComponent<MeshRenderer>().material;

            if (material != null)
            {
                switch (coinType)
                {
                    case ECoinType.Red:
                        material.color = Color.red;
                        break;

                    case ECoinType.Green:
                        material.color = Color.green;
                        break;

                    case ECoinType.Blue:
                        material.color = Color.blue;
                        break;
                }
            }
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (coinType == ECoinType.Red)
        {
            print("Picked a red coin");
        }
        else if (coinType == ECoinType.Green)
        {
            print("Picked a green coin");
        }
        else if (coinType == ECoinType.Blue)
        {
            print("Picked a blue coin");
        }

        //switch (coinType)
        //{
        //    case ECoinType.Red:
        //        print("Picked a red coin");
        //        break;

        //    case ECoinType.Green:
        //        print("Picked a red coin");
        //        break;

        //    case ECoinType.Blue:
        //        print("Picked a red coin");
        //        break;
        //}

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}