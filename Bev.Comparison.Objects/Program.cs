using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Bev.Comparison.Objects.Objects;
using Bev.Comparison.Objects.Objects.Report;
using Bev.Comparison.Objects.Objects.Report.Artefact;

namespace Bev.Comparison.Objects
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            #region Institutes
            Institute bev = new Institute
            {
                NmiFullName = "Bundesamt für Eich- und Vermessungswesen",
                NmiAcronym = "BEV",
                Country = "Austria",
                Address = "Arltgasse 35, 1160 Wien, Austria",
                RMO = "EURAMET",
                CountryCodeISO3166_1 = "AT"
            };

            Institute smu = new Institute
            {
                NmiFullName = "Slovenský metrologický ústav",
                NmiAcronym = "SMU",
                Country = "Slovak Republic",
                Address = "Karloveská 63, 842 55 Bratislava",
                RMO = "EURAMET",
                CountryCodeISO3166_1 = "SK"
            };

            Institute cnam = new Institute
            {
                NmiFullName = "Conservatoire national des arts et métiers",
                NmiAcronym = "LNE-LCM/Cnam",
                Country = "France",
                Address = "61 rue du Landy, 93210 la plaine saint-Denis",
                RMO = "EURAMET",
                CountryCodeISO3166_1 = "FR"
            };

            Institute npl = new Institute
            {
                NmiFullName = "National Physics Laboratory",
                NmiAcronym = "NPL",
                Country = "Great Britain",
                Address = "Hampton Road, TW11 0LW,Teddington",
                RMO = "EURAMET",
                CountryCodeISO3166_1 = "GB"

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
            Person santos = new Person
            {
                Name = "Joao-Pedro Santos da Costa",
                Role = null,
                Affiliation = bev,
                Email = "joao-pedro.santos-da-costa@bev.gv.at"
            };
            Person lewis = new Person
            {
                Name = "Andrew Lewis",
                Role = null,
                Affiliation = npl,
                Email = "andrew.lewis@npl.co.uk"
            };
            #endregion

            #region Description
            Description description = new Description
            {
                ContactPerson = new[] { matus },
                Content = "long description with ...",
                Reference = "DOI ????",
                ReleaseDate = DateTime.Today
            };
            #endregion

            #region CNAM Draft A Report
            ParticipantData participantDataCnam = new ParticipantData
            {
                ContactPerson = wallerand,
                Participant = cnam,
                DateOfMeasurements = "23.05.2022 - 24.05.2022",
                Host = bev
            };
            ArtefactDescription artefactDescriptionCnam = new ArtefactDescription
            {
                Designation = "INM9",
                Manufacturer = "LNE-LCM/Cnam",
                Model = "Prototype",
                SerialNumber = "INM9",
                ApproxWavelength = new Quantity(633, "\\nano\\metre"),
                OperationPrinciple = "MEP 2003",
                LastCompared = "2005 BIPM-K11"
            };
            ArtefactDetail artefactDetailCnam = new ArtefactDetail
            {
                LaserType = "Iodine stabilised HeNe Laser",
                StabilisationTechnique = "Saturation spectroscopy on iodine vapour, 3f frequency modulation",
                DitherFrequency = new Quantity(5.5, "\\kilo\\hertz"),
                ModulationFrequency = new Quantity(6.0, "\\mega\\hertz"),
                IodineCell = "BIPM #9, 8 cm, Brewster windows",
                LaserCavityLength = new Quantity(40, "\\centi\\metre"),
                CavityDetails = "M1: 60 cm, 1 %, iodine cell side, output mirror, M2: plane, 1 %, rear, tube side"
            };
            WorkingParameter wpPcnam = new WorkingParameter
            {
                Parameter = "Output power",
                NominalValue = new Quantity(100, "\\micro\\watt"),
                SensitivityCoefficient = new Quantity(null, -0.04, "\\kilo\\hertz\\per\\micro\\watt", 0.01),
                Comment = "2022 re-measured at LNE-LCM/Cnam"
            };
            WorkingParameter wpMcnam = new WorkingParameter
            {
                Parameter = "Modulation width",
                NominalValue = new Quantity(6.0, "\\mega\\hertz"),
                SensitivityCoefficient = new Quantity(null, -10.2, "\\kilo\\hertz\\per\\mega\\hertz", 1.0),
                Comment = "2022 re-measured at LNE-LCM/Cnam"
            };
            WorkingParameter wpTcnam = new WorkingParameter
            {
                Parameter = "Iodine cell cold finger temperature",
                NominalValue = new Quantity(15.0, "\\degreecelsius"),
                SensitivityCoefficient = new Quantity(null, -13, "\\kilo\\hertz\\per\\degreecelsius", 1),
                Comment = "2022 re-measured at LNE-LCM/Cnam"
            };
            ArtefactReferenceConditions artefactReferenceConditionsCnam = new ArtefactReferenceConditions
            {
                WorkingParameters = new[] { wpPcnam, wpMcnam, wpTcnam }
            };
            Artefact artefactCnam = new Artefact
            {
                ArtefactDescription = artefactDescriptionCnam,
                ArtefactDetail = artefactDetailCnam,
                ArtefactReferenceConditions = artefactReferenceConditionsCnam
            };
            DescriptionOfMeasurements descriptionOfMeasurementsCnam = new DescriptionOfMeasurements
            {
                Method = "A femtosecond fiber laser comb generator (BEV) is used to measure the absolute frequency of the 633 nm standard. The output beam of the standard is transferred to the comb via free space, avoiding optical feedback using a double stage Faraday isolator. All counters and synthesizers are referenced to an active hydrogen maser. This maser is part of the BEV clock assemble which takes part in the CCTF-K001.UTC key comparison thus providing a link to the SI.",
                Condition = "The measurements are made in accordance with the BEV quality system (respective working document A_0118). The laser was put into operation one week before the actual measurements (however not locked). A measurement of 4000 s was made with a sample time of 1 s (raw data filename LNE_2022_f_01.dat). This data was used to determine the KCRV. Immediately before and after this section the working parameters have been determined. Possible cycle slips and outliers are automatically detected and removed using a schema described in the references of the technical protocol and the working document A_0118.",
                AllanVariance = "A long run absolute frequency measurement of the laser was used to determine the relative overlapping Allan standard deviation (raw data filename LNE_2022_f_02.dat, 70 000 s)."
            };
            Results resultsCnam = new Results
            {
                MeasurementResult = new Quantity("Expected frequency f_e (C.1)", 473_612_353_602.3, "\\kilo\\hertz", 12.0),
                UncorrectedMeasuredFrequency = new Quantity("Measured frequency (uncorrected) f_0 (C.2)", 473_612_353_611.806, "\\kilo\\hertz", 0.073),
                MeasuredFrequency = new Quantity("KCRV - Measured frequency f_m (C.4)", 473_612_353_607.543, "\\kilo\\hertz", 1.717),
                OverallFrequencyCorrection = new Quantity("Overall frequency correction f_p (C.3)", -4.263, "\\kilo\\hertz", 1.715),
                FrequencyDifference = new Quantity("Frequency Difference (C.5)", -5.243, "\\kilo\\hertz", 12.122),
                FractionalFrequencyDifference = new Quantity("Fractional frequency Difference (C.5)", -11.1e-12, "\\one", 25.6e-12),
                DegreeOfEquivalence = new Quantity("E_n Value (C.5)", -0.22, "\\one")
            };
            WorkingParameterCorrection wpc11 = new WorkingParameterCorrection
            {
                Parameter = "Output power",
                ActualValue = new Quantity(null, 99, "\\micro\\watt", 5),
                FrequencyCorrection = new Quantity(null, -0.040, "\\kilo\\hertz", 0.200)
            };
            WorkingParameterCorrection wpc12 = new WorkingParameterCorrection
            {
                Parameter = "Modulation width",
                ActualValue = new Quantity(null, 5.586, "\\mega\\hertz", 0.100),
                FrequencyCorrection = new Quantity(null, -4.223, "\\kilo\\hertz", 1.101)
            };
            WorkingParameterCorrection wpc13 = new WorkingParameterCorrection
            {
                Parameter = "Iodine cell cold finger temperature",
                ActualValue = new Quantity(null, 15.0, "\\degreecelsius", 0.1),
                FrequencyCorrection = new Quantity(null, 0.000, "\\kilo\\hertz", 1.300)
            };
            resultsCnam.Corrections = new[] { wpc11, wpc12, wpc13 };

            // collate all appedices
            MeasurementReport cnamDraftA = new MeasurementReport
            {
                ParticipantData = participantDataCnam,
                Artefact = artefactCnam,
                Results = resultsCnam,
                DescriptionOfMeasurements = descriptionOfMeasurementsCnam
            };
            #endregion

            #region SMU Draft A Report
            ParticipantData participantDataSmu = new ParticipantData
            {
                ContactPerson = fira,
                Participant = smu,
                DateOfMeasurements = "27.09.2022 – 30.09.2022",
                Host = bev
            };
            ArtefactDescription artefactDescriptionSmu = new ArtefactDescription
            {
                Designation = "SMU-1",
                Manufacturer = "Winters Electro Optics",
                Model = "Model 100",
                SerialNumber = "204",
                ApproxWavelength = new Quantity(633, "\\nano\\metre"),
                OperationPrinciple = "MEP 2003",
                LastCompared = "June 2010 (CCL-K11)"
            };
            ArtefactDetail artefactDetailSmu = new ArtefactDetail
            {
                LaserType = "Iodine stabilised HeNe Laser",
                StabilisationTechnique = "Saturation spectroscopy on iodine vapour, 3f frequency modulation",
                DitherFrequency = new Quantity(8.333, "\\kilo\\hertz"),
                ModulationFrequency = new Quantity(6.0, "\\mega\\hertz"),
                IodineCell = "BIPM #426, 10 cm, Brewster windows",
                LaserCavityLength = new Quantity(26.5, "\\centi\\metre"),
                CavityDetails = "M1: 30 cm, 0.7 % , front, output mirror, M2: plane, 0.25 %, rear"
            };
            WorkingParameter wpPsmu = new WorkingParameter
            {
                Parameter = "Output power",
                NominalValue = new Quantity(52, "\\micro\\watt"),
                SensitivityCoefficient = new Quantity(null, -0.0082, "\\kilo\\hertz\\per\\micro\\watt", 0.0066),
                Comment = "Measured 2010 at SMU"
            };
            WorkingParameter wpMsmu = new WorkingParameter
            {
                Parameter = "Modulation width",
                NominalValue = new Quantity(6.0, "\\mega\\hertz"),
                SensitivityCoefficient = new Quantity(null, -6.71, "\\kilo\\hertz\\per\\mega\\hertz", 0.50),
                Comment = "Measured 2010 at SMU"
            };
            WorkingParameter wpTsmu = new WorkingParameter
            {
                Parameter = "Iodine cell cold finger temperature",
                NominalValue = new Quantity(12.9, "\\degreecelsius"),
                SensitivityCoefficient = new Quantity(null, -12.51, "\\kilo\\hertz\\per\\degreecelsius", 3.20),
                Comment = "Measured 2010 at SMU"
            };
            ArtefactReferenceConditions artefactReferenceConditionsSmu = new ArtefactReferenceConditions
            {
                WorkingParameters = new[] { wpPsmu, wpMsmu, wpTsmu }
            };
            Artefact artefactSmu = new Artefact
            {
                ArtefactDescription = artefactDescriptionSmu,
                ArtefactDetail = artefactDetailSmu,
                ArtefactReferenceConditions = artefactReferenceConditionsSmu
            };
            DescriptionOfMeasurements descriptionOfMeasurementsSmu = new DescriptionOfMeasurements
            {
                Method = "A femtosecond fiber laser comb generator (BEV) is used to measure the absolute frequency of the 633 nm standard. The output beam of the standard is transferred to the comb via free space, avoiding optical feedback using a double stage Faraday isolator. All counters and synthesizers are referenced to an active hydrogen maser. This maser is part of the BEV clock assemble which takes part in the CCTF-K001.UTC key comparison thus providing a link to the SI.",
                Condition = "The measurements are made in accordance with the BEV quality system (respective working document A_0118). The laser was put into operation one day before the actual measurements (manually locked). A measurement of 6900 s was made with a sample time of 1 s (raw data filename SMU_2022_02.dat). This data was used to determine the KCRV. Immediately before and after this section the working parameters have been determined. Possible cycle slips and outliers are automatically detected and removed using a schema described in the references of the technical protocol and the working document A_0118.",
                Observation = "The laser model tested in this comparison comes with an automatic line detection. The operator decided to lock the laser manually, since he has doubt on the reliability of this system.",
                AllanVariance = "A long run absolute frequency measurement of the laser was used to determine the relative overlapping Allan standard deviation (raw data filename SMU_2022_03.dat, 80 000 s)."
            };
            Results resultsSmu = new Results
            {
                MeasurementResult = new Quantity("Expected frequency f_e (C.1)", 473_612_353_638, "\\kilo\\hertz", 10.0),
                UncorrectedMeasuredFrequency = new Quantity("Measured frequency (uncorrected) f_0 (C.2)", 473_612_353_638.681, "\\kilo\\hertz", 0.075),
                MeasuredFrequency = new Quantity("KCRV - Measured frequency f_m (C.4)", 473_612_353_638.681, "\\kilo\\hertz", 0.075),
                //OverallFrequencyCorrection = new Quantity("Overall frequency correction f_p (C.3)", 0, "\\kilo\\hertz", 0),
                FrequencyDifference = new Quantity("Frequency Difference (C.5)", -0.681, "\\kilo\\hertz", 10.000),
                FractionalFrequencyDifference = new Quantity("Fractional frequency Difference (C.5)", -1.4e-12, "\\one", 21.1e-12),
                DegreeOfEquivalence = new Quantity("E_n Value (C.5)", -0.03, "\\one")
            };
            WorkingParameterCorrection wpc21 = new WorkingParameterCorrection
            {
                Parameter = "Output power",
                ActualValue = new Quantity(null, 46, "\\micro\\watt", 5),
            };
            WorkingParameterCorrection wpc22 = new WorkingParameterCorrection
            {
                Parameter = "Modulation width",
                ActualValue = new Quantity(null, 5.998, "\\mega\\hertz", 0.100),
            };
            WorkingParameterCorrection wpc23 = new WorkingParameterCorrection
            {
                Parameter = "Iodine cell cold finger temperature",
                ActualValue = new Quantity(null, 12.9, "\\degreecelsius", 0.1),
            };
            resultsSmu.Corrections = new[] { wpc21, wpc22, wpc23 };

            // collate all appedices
            MeasurementReport smuDraftA = new MeasurementReport
            {
                ParticipantData = participantDataSmu,
                Artefact = artefactSmu,
                Results = resultsSmu,
                DescriptionOfMeasurements = descriptionOfMeasurementsSmu
            };
            #endregion

            #region 1 Document control
            DocumentControlItem dci1 = new DocumentControlItem
            {
                DocumentVersion = "Version Draft B",
                IssueDate = new DateTime(2023, 04, 25)
            };
            DocumentControlItem dci2 = new DocumentControlItem
            {
                DocumentVersion = "Version Draft B.1",
                IssueDate = new DateTime(2023, 05, 20)
            };
            DocumentControl documentControl = new DocumentControl
            {
                Versions = new[] { dci1, dci2 }
            };
            #endregion

            #region 2 Introduction
            string p1 = "The metrological equivalence of national measurement standards and of calibration certificates issued by national metrology institutes is established by a set of key and supplementary comparisons chosen and organized by the Consultative Committees of the CIPM or by the regional metrology organizations in collaboration with the Consultative Committees.";
            string p2 = "At its meeting in September 2007, the CCL decided upon a key comparison of optical frequency and wavelength standards, named CCL-K11, with BEV as the pilot laboratory. The comparison was registered in 2008 and it is supposed as an on-going comparison.";
            string p3 = "This document constitutes the twelfth final report for the ongoing key comparison CCL-K11.";

            Introduction introduction = new Introduction
            {
                Paragraphs = new[] { p1, p2, p3 }
            };
            #endregion

            #region 7 Analysis

            Discussion discussion = new Discussion
            {
                Text = "to be discussed"
            };

            Analysis analysis = new Analysis
            {
                Text = "to be discussed",
                Discussion = discussion
            };

            #endregion

            #region A Appendix
            AppendixA appendix = new AppendixA
            {
                Title = "Equipment and measuring processes of the participants",
                Text = "Details of the individual equipment, standards and measurement data.",
                ReportsDraftA = new[] { cnamDraftA, smuDraftA }
            };
            #endregion

            ComparisonReport cclK11_2022 = new ComparisonReport
            {
                ShortTitle = "CCL-K11 (2022)",
                FullTitle = "CCL-K11 Comparison of optical frequency and wavelength standards for the period 2022",
                Authors = new[] { matus, fira, wallerand, zechner, santos, lewis },
                Description = description,
                ComparisonType = "Key Comparison",
                ReportType = "Draft B report",
                DocumentControl = documentControl,
                Introduction = introduction,
                Participants = new[] { smu, cnam },
                Analysis = analysis,
                Appendix = appendix
            };

            Console.WriteLine(GenerateXml(cclK11_2022, "CCL-K11_2022.xml"));

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

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
