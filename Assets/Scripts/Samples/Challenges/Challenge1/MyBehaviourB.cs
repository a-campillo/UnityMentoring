using UnityEngine;

public class MyBehaviourB : MonoBehaviour
{
    [SerializeField]
    private int myInt;

    public void PrintMyInt() => print($"MyBehaviourB's myInt: {myInt}");

    public void ChangeMyInt(int newValue)
    {
        //if (myInt == newValue)
        //{
        //    myInt = -1;
        //}
        //else
        //{
        //    myInt = newValue;
        //}

        myInt = (myInt == newValue) ? -1 : newValue;

        print($"myInt's new value: {myInt}");
    }
}