using System;

public class Clinic
{
    private Pet[] rooms;

    public Clinic(string name, int rooms)
    {
        this.Name = name;
        this.Rooms = new Pet[rooms];
    }

    public string Name { get; }

    public Pet[] Rooms
    {
        get { return this.rooms; }
        private set
        {
            if (value.Length % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.rooms = value;
        }
    }
}