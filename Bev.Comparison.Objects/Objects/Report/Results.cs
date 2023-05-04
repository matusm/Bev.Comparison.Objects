namespace Bev.Comparison.Objects.Objects.Report
{
    public class Results
    {
        // TP appendix C.1
        public Quantity MeasurementResult;  // the measurand

        // TP appendix C.2
        public Quantity UncorrectedMeasuredFrequency;

        // TP appendix C.3
        public WorkingParameterCorrection[] Corrections;
        public Quantity OverallFrequencyCorrection;

        // TP appendix C.4
        public Quantity MeasuredFrequency; // the KCRV

        // TP appendix C.5
        public Quantity FrequencyDifference; 
        public Quantity FractionalFrequencyDifference;
        public Quantity DegreeOfEquivalence;
    }

    public class WorkingParameterCorrection
    {
        public string Parameter;
        public Quantity ActualValue;
        public Quantity FrequencyCorrection;
    }
}
