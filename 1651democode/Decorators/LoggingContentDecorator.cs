using System;

namespace _1651democode.Display
{
    public class LoggingContentDecorator : PostDecorator
    {
        public LoggingContentDecorator(IPostDisplay postDisplay) : base(postDisplay) { }

        public override string GetContent()
        {
            Console.WriteLine("[LOG] Accessed content");
            return base.GetContent();
        }

        public override string GetPreview()
        {
            Console.WriteLine("[LOG] Accessed preview");
            return base.GetPreview();
        }
    }
}
