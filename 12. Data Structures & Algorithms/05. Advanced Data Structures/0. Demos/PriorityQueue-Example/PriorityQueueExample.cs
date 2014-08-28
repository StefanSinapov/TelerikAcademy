using System;

class PriorityQueueExample
{
    static void Main()
    {
        PriorityQueue<Person> people = new PriorityQueue<Person>();
        people.Enqueue(new Person("Doncho", 25));
        people.Enqueue(new Person("Niki", 24));
        people.Enqueue(new Person("Ivo", 25));
        people.Enqueue(new Person("Asya", 22));
        people.Enqueue(new Person("Pesho", int.MinValue));
        while (people.Count > 0)
        {
            Console.WriteLine(people.Dequeue());
        }
    }
}

class Person : IComparable<Person>
{
    string Name { get; set; }

    int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Person other)
    {
        return this.Age.CompareTo(other.Age);
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}", Name, Age);
    }
}
