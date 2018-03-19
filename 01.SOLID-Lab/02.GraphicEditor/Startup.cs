namespace GraphicEditor
{
    using Core;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(new Circle());
            graphicEditor.DrawShape(new Square());
            graphicEditor.DrawShape(new Rectangle());
        }
    }
}