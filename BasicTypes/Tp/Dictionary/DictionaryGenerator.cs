using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using BasicTypes.FileProcessing;
using NUnit.Framework;

namespace BasicTypes.Dictionary
{
    [TestFixture]
    public class DictionaryGeneratorTest
    {
        [Test]
        public void Test()
        {
            DictionaryGenerator g = new DictionaryGenerator();
            g.Generate();
        }
    }



    public class DictionaryGenerator
    {

        public DictionaryGenerator()
        {

        }

        public void Generate()
        {
            string file = @"C:\Users\mmartin\code\GitHub\tokipona.parser\BasicTypes\Dictionary\RawData.xlsx";
            ExcelReader excelReader = new ExcelReader(file);
            using (OleDbDataReader reader = excelReader.GetTable(0))
            {
                while (reader.Read())
                {
                    if (reader[1] != null && reader[1] != DBNull.Value && reader[1].ToString() != "")
                    {
                        Console.WriteLine("public static Word " + (reader.GetValue(1) ?? "") + ";");
                    }

                    reader.Read();
                }

            }

            using (OleDbDataReader reader = excelReader.GetTable(0))
            {


                
                for (int i = 0; i < reader.FieldCount - 1; i++)
                {
                    if (reader.GetName(i).EndCheck(" "))
                    {
                        throw new InvalidOperationException("Invalid file format, column ends in significant white space : " + reader.GetName(i));
                    }
                    Console.Write(reader.GetName(i) + "|");
                }



                while (reader.Read())
                {
                    //for (int i = 0; i < reader.FieldCount - 1; i++)
                    //{
                    object[] objects = new object[reader.FieldCount];
                    var o = reader.GetValues(objects);

                    StringBuilder language1 = new StringBuilder();
                    for (int i = 0; i < reader.FieldCount - 1; i++)
                    {
                        if (i < 2) continue;
                        string middleMiddle = String.Format(@"{0}.Add(""{1}"", {2});",
                            objects[0] ?? "",
                            reader.GetName(i).Trim(),
                            CreateArray(reader[i]));
                        if (reader[i] != null && reader[i] != DBNull.Value && reader[i].ToString() != "")
                        {
                            language1.AppendLine(middleMiddle);
                        }
                    }
                    string perLanguageTemplate = @"
    {{
        var {0} = new Dictionary<string, string[]>();
        {1}
        glossMap.Add(""{0}"", {0});
    }}";
                    string language1Code = string.Format(perLanguageTemplate, objects[0], language1);

                    //2nd lang
                    reader.Read();
                    objects = new object[reader.FieldCount];
                    o = reader.GetValues(objects);

                    StringBuilder language2 = new StringBuilder();
                    for (int i = 0; i < reader.FieldCount - 1; i++)
                    {
                        if (i < 2) continue;
                        string middleMiddle = String.Format(@"{0}.Add(""{1}"", {2});",
                            objects[0] ?? "",
                            reader.GetName(i).Trim(),
                            CreateArray(reader[i]));
                        if (reader[i] != null && reader[i] != DBNull.Value && reader[i].ToString() != "")
                        {
                            language2.AppendLine(middleMiddle);
                        }
                    }



                    string language2Code = string.Format(perLanguageTemplate, objects[0], language2);


                    string perWordTemplate = @"
        {{
            var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            {0}
            {1} = new Word(""{1}"");

            Dictionary.Add(""{1}"",{1});
            Glosses.Add(""{1}"",glossMap);
        }}
";


                    string footer = String.Format(perWordTemplate, language1Code + language2Code, objects[1]);
                    Console.WriteLine(footer);
                }
            }

        }

        private static void DumpValues(OleDbDataReader reader)
        {
            while (reader.Read())
            {
                //for (int i = 0; i < reader.FieldCount - 1; i++)
                //{
                object[] objects = new object[reader.FieldCount];
                var o = reader.GetValues(objects);
                Console.Write(string.Join("|", objects));
                //}
                Console.WriteLine();
            }
        }

        private string CreateArray(object o)
        {
            if (o == null)
                return "new []{}";
            string value = o.ToString();

            string[] values = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => "\"" + x.Trim() + "\"").ToArray();
            return "new []{" + string.Join(",", values) + "}";
        }
    }
}
