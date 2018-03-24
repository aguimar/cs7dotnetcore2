using System;
using System.Collections.Generic;
using Packt.CS7;

public class ThingOfDefaults{
    public int Population;
    public DateTime When;
    public String Name;
    public List<Person> People;

    public ThingOfDefaults()
    {
        Population = default(int);
        When = default(DateTime);
        Name = default(String);
        People = default(List<Person>);
    }
}