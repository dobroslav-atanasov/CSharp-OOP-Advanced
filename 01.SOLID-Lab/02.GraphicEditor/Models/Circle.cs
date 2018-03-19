namespace GraphicEditor.Models
{
    using System;
    using Interfaces;

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine($"I'm {this.GetType().Name}");
        }
    }
}