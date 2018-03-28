public class Pet
{
    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public string Name { get;}

    public int Age { get; }

    public string Kind { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}