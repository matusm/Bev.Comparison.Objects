using System.Xml.Serialization;

namespace Bev.Comparison.Objects
{

    // this clas is introduced just to have the correct namespace prefix si:real
    public class Quantity
    {
        [XmlElement(ElementName = "real", Namespace = "https://ptb.de/si")]
        public SiReal Real;

        public string Comment;

        public Quantity(double value, string unit) => Real = new SiReal(value, unit);

        public Quantity(string label, double value, string unit) => Real = new SiReal(label, value, unit);

        public Quantity(string label, double value, string unit, double standardUncertainty) => Real = new SiReal(label, value, unit, standardUncertainty);

        public Quantity(SiReal real) => Real = real;

        public Quantity() { }
    }


    [XmlRoot(ElementName = "real", Namespace = "https://ptb.de/si")] // this does not work as expected
    public class SiReal
    {
        public SiReal() { }

        public SiReal(double value, string unit)
        {
            Value = value;
            Unit = unit;
        }

        public SiReal(string label, double value, string unit) : this(value, unit) => Label = label;

        public SiReal(string label, double value, string unit, double standardUncertainty) : this(label, value, unit) => ExpandedUnc = new SiExpandedUnc(standardUncertainty);

        [XmlElement(ElementName = "label", Namespace = "https://ptb.de/si")]
        public string Label;

        [XmlElement(ElementName = "value", Namespace = "https://ptb.de/si")]
        public double Value;

        [XmlElement(ElementName = "unit", Namespace = "https://ptb.de/si")]
        public string Unit;

        [XmlElement(ElementName = "expandedUnc", Namespace = "https://ptb.de/si")]
        public SiExpandedUnc ExpandedUnc;
    }

    //[XmlRoot(ElementName = "expandedUnc", Namespace = "https://ptb.de/si")]
    public class SiExpandedUnc
    {
        public SiExpandedUnc(double uncertainty)
        {
            Uncertainty = uncertainty;
        }

        public SiExpandedUnc() { }

        [XmlElement(ElementName = "uncertainty", Namespace = "https://ptb.de/si")]
        public double Uncertainty;

        [XmlElement(ElementName = "coverageFactor", Namespace = "https://ptb.de/si")]
        public double CoverageFactor = 1;

        [XmlElement(ElementName = "coverageProbability", Namespace = "https://ptb.de/si")]
        public double CoverageProbability = 0.68;

        [XmlElement(ElementName = "distribution", Namespace = "https://ptb.de/si")]
        public string Distribution = "normal";
    }

}
