using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        public static string s;

        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            //изменил args[3], так как тесты падали с ошибкой 
            //в строке 20, Индекс находился вне границ массивашл
            string format = args[2];
            List<DataContact> group = new List<DataContact>();
            List<GroupData> groups = new List<GroupData>();
            if (count == 2)
            //if (args[1] == "Contact")
            {
                for (int i = 0; i < count; i++)

                {
                    group.Add(new DataContact(TestBase.GenerateRandomString(10))
                    {
                       Lastname = TestBase.GenerateRandomString(20),
                       Address = TestBase.GenerateRandomString(30)
                    });
                }
                if (format == "csv")
                {
                    writeContactToCsvFile(group, writer);
                }
                else if (format == "xml")
                {
                    writeContactToXmlFile(group, writer);
                }
                else if (format == "json")
                {
                    writeContactToJsonFile(group, writer);
                }
                else
                {
                    System.Console.Write("Пиздец, не что то с " + format);
                }
                writer.Close();
            }
            else
            {
                {
                    for (int i = 0; i < count; i++)
                    {
                        groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                        {
                            Header = TestBase.GenerateRandomString(100),
                            Footer = TestBase.GenerateRandomString(100)
                        });
                    }

                    /* Старое значение
                     writer.WriteLine(String.Format("${0},${1},${2}",
                     TestBase.GenerateRandomString(10),
                     TestBase.GenerateRandomString(10),
                     TestBase.GenerateRandomString(10))); */

                    if (format == "csv")
                    {
                        writeGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Write("Пиздец, не что то с " + format);
                    }
                    writer.Close();
                }
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
             writer.WriteLine(String.Format("${0},${1},${2}",
                 group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactToCsvFile(List<DataContact> groups, StreamWriter writer)
        {
            foreach (DataContact group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Firstname, group.Lastname, group.Address));
            }
        }
        static void writeContactToXmlFile(List<DataContact> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<DataContact>)).Serialize(writer, groups);
        }
        static void writeContactToJsonFile(List<DataContact> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

