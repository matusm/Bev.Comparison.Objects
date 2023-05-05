using System;

namespace Bev.Comparison.Objects.Objects
{
    // Report Section 1
    public class DocumentControl
    {
        public DocumentControlItem[] Versions;
    }

    public class DocumentControlItem
    {
        public string DocumentVersion;
        public DateTime IssueDate;
    }
}
