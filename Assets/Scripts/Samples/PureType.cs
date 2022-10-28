public class PureType // : MonoBehaviour
{
    // Public member, can be accessed everywhere
    public string name;

    // Private member, can only be accessed by this object
    private int id;

    // Code below does the same thing.
    //public string GetName()
    //{
    //    return name;
    //}

    // Constructor class to create a new instance of PureType class
    public PureType()
    {
        id = new System.Random().Next(0, 11);
    }

    // Accessors for name (which is already public) and ID
    // (which is private and can't be accessed otherwise
    public string GetName() => name;

    public int GetId() => id;

    public string AreEqual(int a, float b)
    {
        // a == b
        if (a == b)
        {
            return "true"; // not the same as "True", "tRUE", "TRUE"
        }
        else
        {
            return "false";
        }
    }

    //public bool AreEqual(int a, int b)
    //{
    //    // a == b
    //    return a == b;
    //}

    //public int AreEqual(int a, int b)
    //{
    //    return System.Math.Abs(a - b);
    //}

    // Live demo 1: Create an array of values, filled with random nums between 1 and 100
    // Live demo 2: Create a function that compares two numbers and retrieves the greatest/lowest among them
    // Live demo 3: Create a function that retrieves the greates/lowest value in the array
}