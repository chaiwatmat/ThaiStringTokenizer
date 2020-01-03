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
        public Dictionary<char, List<string>> Dictionary { get; protected set; } = new Dictionary<char, List<string>>();

        public MatchingTechnique MatchingTechnique { get; protected set; }

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

        private List<string> InitialWords(List<string> customWords = null)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("ThaiStringTokenizer.dictionary.txt"));
            var stream = assembly.GetManifestResourceStream(resourceName);
            var textStreamReader = new StreamReader(stream);
            var textWords = textStreamReader.ReadToEnd();

            var words = textWords.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

            if (customWords != null && customWords.Any()) { words.InsertRange(0, customWords); }

            return words;
        }

        public void InitialDictionary(List<string> customWords = null)
        {
            var words = InitialWords(customWords);

            foreach (var word in words)
            {
                var firstCharacter = word[0];

                if (!Dictionary.ContainsKey(firstCharacter))
                {
                    Dictionary.Add(firstCharacter, new List<string>());
                }

                Dictionary[firstCharacter].Add(word);
            }
        }
    }
}