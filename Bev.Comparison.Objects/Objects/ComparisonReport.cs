using Bev.Comparison.Objects.Objects;

namespace Bev.Comparison.Objects
{
    public class ComparisonReport
    {
        public string FullName;
        public string ShortName;
        public string Type;
        public string ReportType;
        public Description Description;
        public DocumentControl DocumentControl;
        public Introduction Introduction;
        public Institute[] Participants;
        public Person[] Authors;
        public AppendixA Appendix;
    }
}
