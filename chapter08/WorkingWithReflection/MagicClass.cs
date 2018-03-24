using System;
using System.Reflection;

public class MagicClass
{
    private int magicBaseValue;
    public MagicClass()
    {
        magicBaseValue = 9;
    }
    public int ItsMagic(int preMagic)
    {
        return preMagic * magicBaseValue;
    }
}

public class MagicClass2
{
    private int magicBaseValue;
    public MagicClass2()
    {
        magicBaseValue = 8;
    }
    public int ItsMagic(int preMagic)
    {
        return preMagic * magicBaseValue;
    }
}

public class TestMethodInfo
{
    public static void ExMain()
    {
        // Get the constructor and create an instance of MagicClass
        Type magicType = Type.GetType("MagicClass");
        ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
        object magicClassObject = magicConstructor.Invoke(new object[]{});

        // Get the ItsMagic method and invoke with a parameter value of 100
        MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
        object magicValue = magicMethod.Invoke(magicClassObject, new object[]{100});

        Console.WriteLine("MethodInfo.Invoke() Example\n");
        Console.WriteLine("MagicClass.ItsMagic() returned : {magicValue}");
    }
}

