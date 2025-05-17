using System;

namespace _1651democode.Display
{
    public class TimestampSummaryDecorator : PostDecorator
    {
        public TimestampSummaryDecorator(IPostDisplay postDisplay) : base(postDisplay) { }

        public override string GetSummary()
        {
            return $"{DateTime.Now:HH:mm:ss} | {base.GetSummary()}";
        }
    }
}
