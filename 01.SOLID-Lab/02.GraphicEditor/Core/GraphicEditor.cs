namespace GraphicEditor.Core
{
    using System;
    using Models.Interfaces;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}