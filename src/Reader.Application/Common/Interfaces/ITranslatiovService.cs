
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Application.Common.Interfaces
{
    public class TranslationResult
    {
        public string Translation { get; set; }
    }
    public interface ITranslatiovService
    {

        /// <summary>
        /// Translate text from one language to another
        /// </summary>
        /// <param name="text">text in utf-8</param>
        /// <param name="to">"to" language must be represent as language code</param>
        /// <param name="from">"from" language must be represent as language code, "Auto" 
        /// parameter as value means that translator automatically define the text</param>
        /// <returns></returns>
        Task<TranslationResult> Translate(string text, string to, string from = "Auto");
    }
}
