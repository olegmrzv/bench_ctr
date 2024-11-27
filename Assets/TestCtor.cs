//#define USE_CONSTRUCTOR

using UnityEngine;

public struct MyStruct
{
    public int test0;
    public int test1;

    public MyStruct(int t0, int t1)
    {
        test0 = t0;
        test1 = t1;
    }
}

public class TestCtor : MonoBehaviour
{
    public const int iterations = 10_000_000;
    public MyStruct[] array = new MyStruct[iterations];
    private void Update()
    {
        for (int i = 0; i < iterations; i++)
        {
#if USE_CONSTRUCTOR
            array[i] = new MyStruct(1, 2);
#else
            MyStruct myStruct;
            myStruct.test0 = 1;
            myStruct.test1 = 2;
            array[i] = myStruct;
#endif
        }
    }
}
