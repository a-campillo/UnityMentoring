using UnityEngine;

public class BasicBehaviour : MonoBehaviour
{
    private PureType pureObject;

    // Start is called before the first frame update
    private void Start()
    {
        pureObject = new PureType();
        pureObject.name = "NotPure";
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Same as line below
            //print($"object name: {pureObject.GetName()}");

            Debug.LogFormat("object name: {0}", pureObject.GetName());
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            pureObject.name = "PureAgain";
        }
    }
}