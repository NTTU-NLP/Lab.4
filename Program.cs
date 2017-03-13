using org.apache.tika.metadata;
using org.apache.tika.parser;
using org.apache.tika.parser.html;
using org.apache.tika.sax;
using org.xml.sax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            String html = "<html><head> <title>Best Pizza Joints in America</title></head><body>" +
                          "<p>The best pizza place in the US is <a href=\"http://antoniospizzas.com/\">Antonio's Pizza</a>.</p>" +
                          "<p>It is located in Amherst, MA.</p></body></html>";
            ContentHandler text = new BodyContentHandler();
            LinkContentHandler links = new LinkContentHandler();
            ContentHandler handler = new TeeContentHandler(text, links);
            Metadata metadata = new Metadata();
            org.apache.tika.parser.Parser parser = new HtmlParser();
            ParseContext context = new ParseContext();
            parser.parse(new java.io.ByteArrayInputStream(new UTF8Encoding().GetBytes(html)), handler, metadata, context);
            Console.WriteLine("Title: " + metadata.get(TikaCoreProperties.__Fields.TITLE));
            Console.WriteLine("Body: " + text.ToString());
            Console.WriteLine("Links: " + links.getLinks());
        }
    }
}
