using Bev.Comparison.Objects.Objects.Report;

namespace Bev.Comparison.Objects.Objects
{
    public class MeasurementReport
    {
        public ParticipantData Participant; // TP appendix A "Participant data"
        public Artefact Artefact;           // TP appendix B "Description of artefact"
        public Results Results;             // TP appendix C "Participant Results Report Form"
        public DescriptionOfMeasurements DescriptionOfMeasurements; // TP appendix "Description of Measurements"
    }
}
