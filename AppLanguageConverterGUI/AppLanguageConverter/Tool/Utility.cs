using System;
using AppLanguageConverter.Data;

namespace AppLanguageConverter.Tool
{
    internal static class Utility
    {
        private const string traditionalChinese = "中文";
        private const string english = "英文";
        private const string japanese = "日文";
        private const string korean = "韓文";
        private const string simplifiedChinese = "簡體中文";

        public static string GetLanguageCode(string languageName)
        {
            string languageCode = string.Empty;
            switch (languageName)
            {
                case traditionalChinese:
                    languageCode = "zh-Hant";
                    break;
                case english:
                    languageCode = "en";
                    break;
                case japanese:
                    languageCode = "ja";
                    break;
                case korean:
                    languageCode = "ko";
                    break;
                case simplifiedChinese:
                    languageCode = "zh-Hans";
                    break;
            }

            return languageCode;
        }

        public static string GetLanguageText(LanguageData language, string languageName, bool replaceLinBreak)
        {
            string text;
            switch (languageName)
            {
                case traditionalChinese:
                    text = language.TraditionalChinese;
                    break;
                case english:
                    text = language.English;
                    break;
                case japanese:
                    text = language.Japanese;
                    break;
                case korean:
                    text = language.Korean;
                    break;
                case simplifiedChinese:
                    text = language.SimplifiedChinese;
                    break;
                default:
                    text = string.Empty;
                    break;
            }

            if (replaceLinBreak)
            {
                text = text.Replace("\n", "");
                text = text.Replace("\\n", Environment.NewLine);
            }

            return text;
        }
    }
}
