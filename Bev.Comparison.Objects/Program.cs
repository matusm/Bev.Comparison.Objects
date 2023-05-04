using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Bev.Comparison.Objects.Objects;
using Bev.Comparison.Objects.Objects.Report;
using Bev.Comparison.Objects.Objects.Report.Artefact;

namespace Bev.Comparison.Objects
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }

    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            #region Institutes
            Institute bev = new Institute
            {
                Name = "Bundesamt für Eich- und Vermessungswesen",
                Acronym = "BEV",
                Country = "Austria",
                Address = "Arltgasse 35, 1160 Wien, Austria",
                RMO = "EURAMET",
                CountryCode = "AT"
            };

            Institute smu = new Institute
            {
                Name = "Slovenský metrologický ústav",
                Acronym = "SMU",
                Country = "Slovak Republic",
                Address = "Karloveská 63, 842 55 Bratislava",
                RMO = "EURAMET",
                CountryCode = "SK"
            };

            Institute cnam = new Institute
            {
                Name = "Conservatoire national des arts et métiers",
                Acronym = "LNE-LCM/Cnam",
                Country = "France",
                Address = "61 rue du Landy, 93210 la plaine saint-Denis",
                RMO = "EURAMET",
                CountryCode = "FR"
            };

            Institute npl = new Institute
            {
                Name = "National Physics Laboratory",
                Acronym = "NPL",
                Country = "Great Britain",
                Address = "Teddington",
                RMO = "EURAMET",
                CountryCode = "UK"

            };
            #endregion

            #region Persons
            Person matus = new Person
            {
                Name = "Michael Matus",
                Role = "node",
                Affiliation = bev,
                Email = "michael.matus@bev.gv.at"
            };
            Person fira = new Person
            {
                Name = "Roman Fira",
                Role = "participant",
                Affiliation = smu,
                Email = "fira@smu.gov.sk"
            };
            Person wallerand = new Person
            {
                Name = "Jean-Pierre Wallerand ",
                Role = "participant",
                Affiliation = cnam,
                Email = "jean-pierre.wallerand@cnam.fr"
            };
            Person zechner = new Person
            {
                Name = "Georg Zechner",
                Role = "node",
                Affiliation = bev,
                Email = "georg.zechner@bev.gv.at"
            };
            #endregion

            #region Description
            Description description = new Description
            {
                ContactPerson = new[] { matus },
                Content = "long description with ...",
                Reference = "DOI",
                ReleaseDate = "2023"
            };
            #endregion

            #region Draft A Reports
            // first participant
            ParticipantData participantData1 = new ParticipantData();
            participantData1.ContactPerson = wallerand;
            participantData1.Participant = cnam;
            participantData1.DateOfMeasurements = "23.05.2022 - 24.05.2022";
            participantData1.Host = bev;
            ArtefactDescription artDes1 = new ArtefactDescription();
            artDes1.Designation = "INM9";
            artDes1.Manufacturer = "LNE-LCM/Cnam";
            artDes1.Model = "Prototype";
            artDes1.SerialNumber = "INM9";
            artDes1.OperationPrinciple = "MEP 2003";
            artDes1.LastCompared = "2005 BIPM-K11";
            ArtefactDetail artDet1 = new ArtefactDetail();
            artDet1.LaserType = "Iodine stabilised HeNe Laser";
            artDet1.StabilisationTechnique = "Saturation spectroscopy on iodine vapour, 3f frequency modulation";
            artDet1.DitherFrequency = new Quantity(5.5, "\\kilo\\hertz");
            artDet1.ModulationFrequency = new Quantity(6.0, "\\mega\\hertz");
            artDet1.IodineCell = "BIPM #9, 8 cm, Brewster windows";
            artDet1.LaserCavityLength = new Quantity(40, "\\centi\\metre");
            artDet1.CavityDetails = "M1: 60 cm, 1 %, iodine cell side, output mirror, M2: plane, 1 %, rear, tube side";
            WorkingParameter wpP1 = new WorkingParameter();
            wpP1.Parameter = "Output power";
            wpP1.NominalValue = new Quantity(100, "\\micro\\watt");
            wpP1.SensitivityCoefficient = new Quantity("", -0.04, "\\kilo\\hertz\\per\\micro\\watt", 0.01);
            wpP1.Comment = "2022 re-measured at LNE-LCM/Cnam";
            WorkingParameter wpM1 = new WorkingParameter();
            wpM1.Parameter = "Modulation width";
            wpM1.NominalValue = new Quantity(6.0, "\\mega\\hertz");
            wpM1.SensitivityCoefficient = new Quantity("", -10.2, "\\kilo\\hertz\\per\\mega\\hertz", 1.0);
            wpM1.Comment = "2022 re-measured at LNE-LCM/Cnam";
            WorkingParameter wpT1 = new WorkingParameter();
            wpT1.Parameter = "Iodine cell cold finger temperature";
            wpT1.NominalValue = new Quantity(15.0, "\\degreecelsius");
            wpT1.SensitivityCoefficient = new Quantity("", -13, "\\kilo\\hertz\\per\\degreecelsius", 1);
            wpT1.Comment = "2022 re-measured at LNE-LCM/Cnam";
            ArtefactReferenceConditions ref1 = new ArtefactReferenceConditions();
            ref1.WorkingParameters = new[] { wpP1, wpM1, wpT1 };
            Artefact artefact1 = new Artefact();
            artefact1.ArtefactDescription = artDes1;
            artefact1.ArtefactDetail = artDet1;
            artefact1.ArtefactReferenceConditions = ref1;
            DescriptionOfMeasurements dom1 = new DescriptionOfMeasurements();
            dom1.Method = "A femtosecond fiber laser comb generator (BEV) is used to measure the absolute frequency of the 633 nm standard. The output beam of the standard is transferred to the comb via free space, avoiding optical feedback using a double stage Faraday isolator. All counters and synthesizers are referenced to an active hydrogen maser. This maser is part of the BEV clock assemble which takes part in the CCTF-K001.UTC key comparison thus providing a link to the SI.";
            dom1.Condition = "The measurements are made in accordance with the BEV quality system (respective working document A_0118). The laser was put into operation one week before the actual measurements (however not locked). A measurement of 4000 s was made with a sample time of 1 s (raw data filename LNE_2022_f_01.dat). This data was used to determine the KCRV. Immediately before and after this section the working parameters have been determined. Possible cycle slips and outliers are automatically detected and removed using a schema described in the references of the technical protocol and the working document A_0118.";
            dom1.AllanVariance = "A long run absolute frequency measurement of the laser was used to determine the relative overlapping Allan standard deviation (raw data filename LNE_2022_f_02.dat, 70 000 s).";
            MeasurementReport mr1 = new MeasurementReport();
            mr1.Participant = participantData1;
            mr1.Artefact = artefact1;
            mr1.DescriptionOfMeasurements = dom1;









            #endregion

            Comparison cclK11_2022 = new Comparison
            {
                ShortName = "CCL-K11 (2022)",
                FullName = "CCL-K11 Comparison of optical frequency and wavelength standards for the period 2022",
                Description = description,
                Type = "Key Comparison",
                ReportType = "Draft B report",
                Participants = new[] { smu, cnam },
                Authors = new[] { matus, fira, wallerand, zechner },
                ReportsDraftA = new[] { mr1 }
            };

            Console.WriteLine(GenerateXml(cclK11_2022, "CCL-K11.xml"));

        }

        static string GenerateXml(object obj, string filename)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("si", "https://ptb.de/si");

            XmlSerializer x = new XmlSerializer(obj.GetType());
            Stream fs = new FileStream(filename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.UTF8);
            //x.Serialize(writer, obj);
            x.Serialize(writer, obj, ns);
            writer.Close();

            string utf8;
            using (StringWriter strWriter = new Utf8StringWriter())
            {
                x.Serialize(strWriter, obj, ns);
                utf8 = strWriter.ToString();
            }
            return utf8;
        }
    }
}
