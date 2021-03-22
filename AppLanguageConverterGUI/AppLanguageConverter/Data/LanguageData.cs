using CsvHelper.Configuration.Attributes;

namespace AppLanguageConverter.Data
{
    internal class LanguageData
    {
        [Name("LanguageID")]
        public string LanguageID { get; set; }

        [Name("中文")]
        public string TraditionalChinese { get; set; }

        [Name("英文")]
        public string English { get; set; }

        [Name("日文")]
        public string Japanese { get; set; }

        [Name("韓文")]
        public string Korean { get; set; }

        [Name("簡體中文")]
        public string SimplifiedChinese { get; set; }
    }
}
