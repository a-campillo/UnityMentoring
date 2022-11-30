using UnityEngine;

public class MyBehaviourA : MonoBehaviour
{
    [SerializeField]
    private int myInt = 0;

    [SerializeField]
    private int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    [SerializeField]
    private int myIntArgument;

    [SerializeField]
    private string str1;

    [SerializeField]
    private string str2;

    [SerializeField]
    private MyBehaviourB behaviourB;

    private void IncreaseInt(int desiredNumber)
    {
        do
        {
            myInt += 1;
        } while (myInt <= desiredNumber);
    }

    private bool ArrayHasRepeatedValues()
    {
        bool result = false;

        for (int i = 0; i < intArr.Length; i++)
        {
            for (int j = i + 1; j < intArr.Length; j++)
            {
                if (intArr[i] == intArr[j])
                {
                    result = true;
                    break;
                }
            }

            if (result)
            {
                break;
            }
        }

        return result;
    }

    private bool ArrayHasElement(int element)
    {
        bool result = false;

        foreach (int i in intArr)
        {
            result |= element == i; // result = result || element == i;

            if (result)
            {
                break;
            }
        }

        return result;
    }

    private void SwitchCharacterInString(string str)
    {
        int middleIndex = str.Length / 2;
        char[] strChars = str.ToCharArray();

        for (int i = 0; i < str.Length; i++)
        {
            if (i != middleIndex)
            {
                strChars[i] = str[middleIndex];
            }
        }

        print($"Replaced {str} for {new string(strChars)}");
    }

    // Start is called before the first frame update
    private void Start()
    {
        IncreaseInt(150);
        print($"Increasing myInt to {myInt}");

        print($"intArr has repeated elements: {ArrayHasRepeatedValues()}");

        print($"intArr has {myIntArgument} in collection: {ArrayHasElement(myIntArgument)}");

        behaviourB.PrintMyInt();
        behaviourB.ChangeMyInt(myIntArgument);

        SwitchCharacterInString(str1);
        SwitchCharacterInString(str2);
    }
}