using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AppLanguageConverter.Data;

namespace AppLanguageConverter.Reader
{
    internal class CsvReader
    {
        private List<string> headerList;
        private Dictionary<string, LanguageData> languageDic;

        public bool OpenCSV(string path, int row, int column)
        {
            bool success = false;
            headerList = new List<string>();
            languageDic = new Dictionary<string, LanguageData>();

            try
            {
                using (var reader = new StreamReader(path))
                {
                    using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        for (int i = 0; i <= row; i++)
                        {
                            csv.Read();
                        }
                        csv.ReadHeader();

                        List<string> headers = csv.Context.HeaderRecord.ToList();

                        for (int i = column + 1; i < headers.Count; i++)
                        {
                            headerList.Add(headers[i]);
                        }

                        foreach (var language in csv.GetRecords<LanguageData>())
                        {
                            language.LanguageID = language.LanguageID.Trim();
                            if (language.LanguageID.StartsWith("ID_"))
                            {
                                if (!languageDic.ContainsKey(language.LanguageID))
                                {
                                    languageDic.Add(language.LanguageID, language);
                                }
                            }
                        }

                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                headerList = new List<string>();
                languageDic = new Dictionary<string, LanguageData>();
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        public List<string> GetHeaderList()
        {
            return headerList;
        }

        public Dictionary<string, LanguageData> GetLanguageDictionary()
        {
            return languageDic;
        }
    }
}
