using System.Xml.Linq;

namespace Homework_6.Contracts
{
    public interface IXMLSerializable 
    {
        XElement SerializeToXml();
    }
}
