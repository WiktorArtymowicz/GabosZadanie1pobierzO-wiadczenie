using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml;

namespace GabosZadanie1pobierzOświadczenie
{
    public class Oswiadczenie
    {
        private string _tresc = string.Empty;
        private string _data = string.Empty;
        private string _czas = string.Empty;
        private const string _token = "TUTAJ BĘDZIE TOKEN";

        public Oswiadczenie(string loginLekarza, string podpisLekarza = "Podpis Lekarza")
        {
            DateTime dateTime = DateTime.Now;
            _tresc = $"Logowanie Lekarza przez system zewnętrzny ({loginLekarza} {podpisLekarza})";
            _data = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day).ToString();
            _czas = $"{dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        }

        private string StringToXML()
        {
            return $"<PodpisaneOswiadczenie> <Tresc>{_tresc}</Tresc> <Data>{_data}</Data> <Czas>{_czas}</Czas> <Token>{_token}</Token> </PodpisaneOswiadczenie>";
        }

        public string CreateXML()
        { 
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml($@"{StringToXML()}");
            XmlNode node = xmlDocument.DocumentElement;

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            StringBuilder output = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(output, xmlWriterSettings);

            xmlDocument.Save(xmlWriter);

            return output.ToString();
        }
    }
}
