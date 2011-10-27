using System.IO;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace HtmlToBBCode
{
    public class HtmlToBBCode
    {
        public string Convert(string html, string currentDirecty)
        {
            if (string.IsNullOrEmpty(html))
<<<<<<< HEAD
                return "";//he
=======
                return "";//toma
>>>>>>> toma
            var htmlStream = new StringReader(html);
            var tempStream = new MemoryStream();
            
            var myXPathDoc = new XPathDocument(htmlStream);

            var myXslTrans = new XslTransform();

            myXslTrans.Load(string.Format("{0}/HTMLtoBBCode.xslt", currentDirecty));

            myXslTrans.Transform(myXPathDoc, null, tempStream);

            tempStream.Seek(0, SeekOrigin.Begin);
            var bts = new byte[tempStream.Length];
            tempStream.Read(bts, 0, (int) tempStream.Length);

            var readToEnd = Encoding.UTF8.GetString(bts);
            htmlStream.Close();
            tempStream.Close();
            return readToEnd;
        }
    }
}
