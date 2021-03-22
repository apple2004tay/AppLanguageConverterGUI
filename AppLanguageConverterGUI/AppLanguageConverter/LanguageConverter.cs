using System.Collections.Generic;
using AppLanguageConverter.Reader;
using AppLanguageConverter.Writer;
using AppLanguageConverter.Data;

namespace AppLanguageConverter
{
    public class LanguageConverter
    {
        public List<string> HeaderList { get; private set; }
        private Dictionary<string, LanguageData> languageDic = new Dictionary<string, LanguageData>();

        private CsvReader languageCsvReader = new CsvReader();
        private ResxWriter languageResxWriter = new ResxWriter();
        private XlfWriter languageXlfWriter = new XlfWriter();

        public bool OpenLangaugeCsv(string path, int row, int column)
        {
            bool success = languageCsvReader.OpenCSV(path, row, column);

            if (success)
            {
                HeaderList = languageCsvReader.GetHeaderList();
                languageDic = languageCsvReader.GetLanguageDictionary();
            }

            return success;
        }

        public void CreateMainLanguageResx(string path, int mainLanguageIndex, bool replaceLineBreak)
        {
            string mainLanguageName = HeaderList[mainLanguageIndex];
            languageResxWriter.CreateResxFile(path, languageDic, mainLanguageName, true, replaceLineBreak);
        }

        public void CreateAllLanguageResx(string path, int mainLanguageIndex, bool replaceLineBreak)
        {
            for (int i = 0; i < HeaderList.Count; i++)
            {
                bool mainLanguage = i == mainLanguageIndex;
                string languageName = HeaderList[i];
                languageResxWriter.CreateResxFile(path, languageDic, languageName, mainLanguage, replaceLineBreak);
            }
        }

        public void CreateLanguageXlf(string path, int mainLanguageIndex, bool replaceLineBreak)
        {
            languageXlfWriter.CreateXlfFile(path, HeaderList, mainLanguageIndex, languageDic, replaceLineBreak);
        }
    }
}
