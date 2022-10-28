using UnityEngine;

public class BasicBehaviour : MonoBehaviour
{
    private PureType pureObject;

    private int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 400 };

    // Start is called before the first frame update
    private void Start()
    {
        pureObject = new PureType();
        pureObject.name = "NotPure";
    }

    public void PrintNumbers()
    {
        //int startNum = 11;
        // while-do
        //while (startNum <= 10)
        //{
        //    print(startNum);
        //    startNum++; // startNum += 1; startNum = starNum + 1;
        //}

        //do-while
        //do
        //{
        //    print(startNum);
        //    startNum++; // startNum += 1; startNum = starNum + 1;
        //} while (startNum <= 10);

        //for
        //for (int startNum = 1; startNum <= 10; startNum++)
        //{
        //    print(startNum);
        //}

        for (int i = 0; i < nums.Length; i++)
        {
            print(nums[i]);
        }

        //foreach (int item in nums)
        //{
        //    if (item <= 10)
        //    {
        //        print(item);
        //    }
        //}
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            int a = 3;
            int b = 20;

            //print($"{a} and {b} are equal: {pureObject.AreEqual(a,b)}");
            //print(a + " and " + b + " are equal: " + pureObject.AreEqual(a, b));

            PrintNumbers();
        }
    }
}