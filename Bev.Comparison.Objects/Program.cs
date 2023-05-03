using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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
                Address = "Arltgasse 35, 1160 Wien, Austria"
            };

            Institute smu = new Institute
            {
                Name = "Slovenský metrologický ústav",
                Acronym = "SMU",
                Country = "Slovak Republic",
                Address = "Karloveská 63, 842 55 Bratislava"
            };

            Institute cnam = new Institute
            {
                Name = "Conservatoire national des arts et métiers",
                Acronym = "LNE-LCM/Cnam",
                Country = "France",
                Address = "61 rue du Landy, 93210 la plaine saint-Denis"
            };

            Institute npl = new Institute
            {
                Name = "National Physics Laboratory",
                Acronym = "NPL",
                Country = "Great Britain",
                Address = "Teddington"
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
            #endregion

            #region Description
            Description description = new Description
            {
                ContactPerson = new[] { matus },
                Content = "long description with",
                Reference = "DOI",
                ReleaseDate = "2023"
            };
            #endregion

            #region Quantities

            Quantity frequencyLab1 = new Quantity( new SiReal("corrected frequency", 473456654.345, "\\kilo\\hertz", 0.9876));

            Quantity iodineTemperature1 = new Quantity(new SiReal("iodine cold finger temperature", 15.01, @"\degreecentigrade"));

            Quantity power = new Quantity(new SiReal(67, "\\micro\\watt"));

            #endregion

            Comparison cclK11_2022 = new Comparison
            {
                ShortName = "CCL K11 (2022)",
                FullName = "Comparison of optical frequency and wavelength standards",
                Description = description,
                Type = "Key Comparison",
                ReportType = "Draft B report",
                Participants = new[] { smu, cnam },
                Authors = new[] { matus, fira, wallerand },
                Quantities = new[] { frequencyLab1, iodineTemperature1, power }
            };

            Console.WriteLine( GenerateXml(cclK11_2022, "CCL-K11.xml") );

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
