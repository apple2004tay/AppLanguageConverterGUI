using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using AppLanguageConverter.Tool;
using AppLanguageConverter.Data;

namespace AppLanguageConverter.Writer
{
    internal class ResxWriter
    {
        private bool replaceLinBreak;

        public void CreateResxFile(string path, Dictionary<string, LanguageData> languageDic, string languageName, bool mainLanguage, bool replaceLinBreak)
        {
            this.replaceLinBreak = replaceLinBreak;
            using (ResXResourceWriter resx = new ResXResourceWriter($"{path}\\{GetResxFileName(languageName, mainLanguage)}"))
            {
                foreach (var item in languageDic)
                {
                    resx.AddResource(item.Key, Utility.GetLanguageText(item.Value, languageName, replaceLinBreak));
                }

                resx.Generate();
            }
        }

        private string GetResxFileName(string languageName, bool mainLanguage)
        {
            string languageCode = Utility.GetLanguageCode(languageName);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("AppLanguage");

            if (!mainLanguage)
            {
                stringBuilder.Append($".{languageCode}");
            }

            stringBuilder.Append(".resx");
            return stringBuilder.ToString();
        }
    }
}
