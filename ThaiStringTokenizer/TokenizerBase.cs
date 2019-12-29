using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ThaiStringTokenizer.Handlers;

namespace ThaiStringTokenizer
{
    public abstract class TokenizerBase
    {
        public Dictionary<char, List<string>> Dictionary { get; set; } = new Dictionary<char, List<string>>();

        public bool RemoveSpace { get; set; }

        public bool ShortWordFirst { get; set; }

        public List<string> Words { get; set; }
        public List<ICharacterHandler> GetCharacterHandlers()
        {
            return new List<ICharacterHandler>
            {
                new EnglishCharacterHandler(),
                new NumberCharacterHandler(),
                new ThaiCharacterHandler(),
                new UnknownCharacterHandler()
            };
        }

        public void InitialWords(List<string> customWords)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("ThaiStringTokenizer.dictionary.txt"));
            var stream = assembly.GetManifestResourceStream(resourceName);
            var textStreamReader = new StreamReader(stream);
            var textWords = textStreamReader.ReadToEnd();

            Words = textWords.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

            if (customWords != null) { Words.InsertRange(0, customWords); }
        }

        public void InitialDictionary()
        {
            foreach (var word in Words)
            {
                var firstCharacter = word[0];

                if (!Dictionary.ContainsKey(firstCharacter))
                {
                    Dictionary.Add(word[0], new List<string>());
                }

                Dictionary[firstCharacter].Add(word);
            }
        }
    }
}