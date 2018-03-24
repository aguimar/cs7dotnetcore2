using System;
using System.Reflection;
using static System.Console;
using System.Linq;

namespace WorkingWithReflection
{
    class Dog
    {
        
    }
    
    class Program
    {
        [Coder("Mark Price", "22 August 2017")]
        public static void DoStuff()
        {

        }
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata:");
            Assembly assembly = Assembly.GetEntryAssembly();

            WriteLine($" Full name: {assembly.FullName}");
            WriteLine($" Location: {assembly.Location}");

            var attributes = assembly.GetCustomAttributes();

            WriteLine($" Attributes:");
            foreach (Attribute a in attributes)
            {
                WriteLine($" {a.GetType()}");
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($" Version: {version.InformationalVersion}");

            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($" Company: {company.Company}");

            WriteLine($"Types:");
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                WriteLine($" Name: {type.FullName}");

                MemberInfo[] members = type.GetMembers();
                foreach (MemberInfo member in members)
                {
                    WriteLine($" {member.MemberType}: {member.Name} ({member.DeclaringType.Name})");

                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);

                    foreach (CoderAttribute coder in coders)
                    {
                        WriteLine($" Modified by {coder.Coder} on {coder.LastModified.ToShortDateString()}");
                    }
                }
            }

            // Get the constructor and create an instance of MagicClass
            
            var mc = new MagicClass();
            var mc2 = new MagicClass2();

            string tipo = "MagicClass3";
            
            Type magicType = Type.GetType(tipo);
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[]{});

            // Get the ItsMagic method and invoke with a parameter value of 100
            MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
            object magicValue = magicMethod.Invoke(magicClassObject, new object[]{100});

            Console.WriteLine("MethodInfo.Invoke() Example\n");
            Console.WriteLine($"MagicClass.ItsMagic() returned : {magicValue}");
        }
    }
}
