using System;

class Person
{
    public string name;
    public int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Introduce()
    {
        Console.WriteLine($"Hi {name}, Welcome to C#");
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person("Name1",1);
        Person p2 = new Person("Name2",2);
        Person p3 = new Person("Name3",3);

        p1.Introduce();
        p2.Introduce();
        p3.Introduce();

    }
}