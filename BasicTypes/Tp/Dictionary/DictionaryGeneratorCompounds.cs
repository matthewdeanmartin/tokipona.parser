using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using NUnit.Framework;

namespace BasicTypes.Dictionary
{

    [TestFixture]
    public class DictionaryGeneratorCompoundsTest
    {
        [Test]
        public void Test()
        {
            Dictionary.DictionaryGeneratorCompounds g = new Dictionary.DictionaryGeneratorCompounds();
            g.Generate();
        }
    }



    public class DictionaryGeneratorCompounds
    {

        public void Generate()
        {
            //View Schema
            string file = @"C:\Users\mmartin\code\GitHub\tokipona.parser\BasicTypes\Dictionary\PreprocessedCompounds.xlsx";
            using (OleDbConnection connection = new OleDbConnection(DetermineOledBConnectionString(file)))
            {
                connection.Open();
                DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (schema == null)
                {
                    throw new InvalidOperationException("connection.GetOleDbSchemaTable returned a null table");
                }

                int tab = 0;
                foreach (DataRow row in schema.Rows)
                {
                    tab++;
                    if(tab>1) continue;
                    
                    string table = row["TABLE_NAME"].ToString();

                    string sql = "SELECT * FROM [" + table + "] ORDER BY 3 asc;";
                   
                    using (OleDbCommand com = new OleDbCommand(sql))
                    {
                        com.Connection = connection;

                        using (OleDbDataReader reader = com.ExecuteReader())
                        {
                            //Console.WriteLine("Row Count " + DumpValues(reader));
                            //return;
                            while (reader.Read())
                            {
                                if (!string.IsNullOrEmpty(reader[0].ToString())) continue;
                                if (!string.IsNullOrEmpty(reader[1].ToString())) continue;

                                string prospectiveWord = reader[2].ToString();

                                //Anything that has implicit slots, it's a template.
                                //If it is a simple phrase, it *could* have slots, but its going to just be modifiers (potentially infixed).
                                //TODO: 

                                if (prospectiveWord.ContainsCheck(" li ")) continue; //sentence
                                if (prospectiveWord.ContainsCheck(":")) continue;//sentence, template
                                if (prospectiveWord.ContainsCheck("...")) continue; //template
                                if (prospectiveWord.ContainsCheck("X")) continue; //template
                                if (prospectiveWord.ContainsCheck("Y")) continue;//template
                                if (prospectiveWord.ContainsCheck("A")) continue;//template
                                if (prospectiveWord.ContainsCheck("B")) continue;//template

                                if (prospectiveWord.EndCheck(" e ")) continue;//template ... 
                                if (prospectiveWord.EndCheck(" e")) continue;//template ... 
                                if (prospectiveWord.EndCheck(" pi")) continue;//template ... varies depending on what follows pi
                                if (prospectiveWord.EndCheck(" la")) continue;//la fragment...  This means this ONLY when in la positions, so it is a type of template [...] la X => as for [...] X is true.

                                if (prospectiveWord.ContainsCheck(",")) continue;//make up your mind
                                if (prospectiveWord.ContainsCheck("/")) continue;//make up your mind

                                if (reader[2] != null && reader[2] != DBNull.Value && reader[2].ToString() != "")
                                {
                                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                                    string titleCased = textInfo.ToTitleCase(reader[2].ToString());
                                    string seeSharped = titleCased.Replace(" ", "").Trim(new char[]{'!','?','.'});

                                    Console.WriteLine("public static CompoundWord " + seeSharped + ";");
                                }

                                //reader.Read();
                            }

                        }
                    }

                    using (OleDbCommand com = new OleDbCommand(sql))
                    {
                        com.Connection = connection;
                        using (OleDbDataReader reader = com.ExecuteReader())
                        {
                            if (reader == null)
                            {
                                throw new InvalidOperationException("Command returned a null reader : " + sql);
                            }
                            for (int i = 0; i < reader.FieldCount - 1; i++)
                            {
                                if (reader.GetName(i).EndCheck(" "))
                                {
                                    throw new InvalidOperationException(
                                        "Invalid file format, column ends in significant white space : " +
                                        reader.GetName(i));
                                }
                                Console.Write(reader.GetName(i) + "|");
                            }


                            Console.WriteLine(@"static CompoundWords()
        {");

                            while (reader.Read())
                            {
                                object[] objects = new object[reader.FieldCount];
                                var o = reader.GetValues(objects);

                                if(!string.IsNullOrEmpty(objects[0].ToString()) ) continue;
                                if (!string.IsNullOrEmpty(objects[1].ToString())) continue;

                                string prospectiveWord = objects[2].ToString();

                                //Anything that has implicit slots, it's a template.
                                //If it is a simple phrase, it *could* have slots, but its going to just be modifiers (potentially infixed).
                                //TODO: 

                                if (prospectiveWord.ContainsCheck(" li ")) continue; //sentence
                                if (prospectiveWord.ContainsCheck(":")) continue;//sentence, template
                                if (prospectiveWord.ContainsCheck("...")) continue; //template
                                if (prospectiveWord.ContainsCheck("X")) continue; //template
                                if (prospectiveWord.ContainsCheck("Y")) continue;//template
                                if (prospectiveWord.ContainsCheck("A")) continue;//template
                                if (prospectiveWord.ContainsCheck("B")) continue;//template

                                if (prospectiveWord.EndCheck(" e ")) continue;//template ... 
                                if (prospectiveWord.EndCheck(" e")) continue;//template ... 
                                if (prospectiveWord.EndCheck(" pi")) continue;//template ... varies depending on what follows pi
                                if (prospectiveWord.EndCheck(" la")) continue;//la fragment...  This means this ONLY when in la positions, so it is a type of template [...] la X => as for [...] X is true.

                                if (prospectiveWord.ContainsCheck(",")) continue;//make up your mind
                                if (prospectiveWord.ContainsCheck("/")) continue;//make up your mind

                                string perWordTemplate = @"
            {{
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {{
                    var en = new Dictionary<string, string[]>();
                    en.Add(""{1}"", new[] {{ {2} }} );
                    glossMap.Add(""en"", en);
                }}
                {0} = new CompoundWord(""{1}"");

                Dictionary.Add(""{1}"", {0});
                Glosses.Add(""{1}"", glossMap);
            }}
";


                                string meanings;
                                

                                string value = objects[3].ToString();
                                if (value.ContainsCheck(","))
                                {
                                    meanings = string.Join(",",
                                        value.Split(new char[] {','}).Select(x => "\"" + x + "\"").ToArray());
                                }
                                else
                                {
                                    meanings = "\"" + value + "\"";
                                }

                                string normalized = objects[2].ToString().Replace(" ", "-").Trim(new char[] { '!', '?', '.' });

                                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                                string titleCased = textInfo.ToTitleCase(objects[2].ToString());
                                string seeSharped = titleCased.Replace(" ", "").Trim(new char[] { '!', '?', '.' });
                                string footer = String.Format(perWordTemplate, seeSharped, normalized, meanings);
                                Console.WriteLine(footer);
                            }
                        }
                    } //using
                } //foreach

            } //using      
        }

        private static int DumpValues(OleDbDataReader reader)
        {
            int i = 0;
            Dictionary<string, string> values = new Dictionary<string, string>();

            while (reader.Read())
            {
                object[] objects = new object[reader.FieldCount];
                int o = reader.GetValues(objects);
                
                if (objects[0].ToString().Trim().ContainsCheck(" "))
                {
                    string word = objects[0].ToString().Trim(new char[] {' ', '.', '<'});
                    string definition = objects[1].ToString().Replace("(?)", "").Replace("?", "");

                    if (definition != "")
                    {
                        if (values.ContainsKey(word))
                        {
                            if (values[word] != definition)
                            {
                                values[word] = string.Join(", ", (values[word] + ", " + definition).Split(new char[] { ',' }).Select(x => x.Trim()).Distinct().ToArray());
                            }
                        }
                        else
                        {
                            values.Add(word, definition);
                        }
                    }
                    
                }
            }

            foreach (KeyValuePair<string, string> pair in values)
            {
                Console.WriteLine(string.Join("\t", new[] { pair.Key, pair.Value }));

                i++;
            }
            return i;
        }


        private string CreateArray(object o)
        {
            if (o == null)
                return "new []{}";
            string value = o.ToString();

            string[] values =
                value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => "\"" + x.Trim() + "\"")
                    .ToArray();
            return "new []{" + string.Join(",", values) + "}";
        }

        public static string DetermineOledBConnectionString(string fullNameOfExcelFile)
        {
            string connectionString;
            if (IntPtr.Size == 4)
            {
                // 32-bit
                //Excel “External table is not in the expected format.” //Means OLEDB.4.0 can't read that version of Excel.
                //"Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;" //Older versions of Excel
                connectionString =
                    string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                        fullNameOfExcelFile);
            }
            else //(IntPtr.Size == 8)
            {
                // 64-bit
                connectionString =
                    string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                        fullNameOfExcelFile);
            }

            return connectionString;
        }

    }
}
