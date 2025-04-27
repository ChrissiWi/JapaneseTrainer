using JapaneseTrainer.Models;

namespace JapaneseTrainer.Data;

public static class DatabaseInitializer
{
    public static void Initialize(JapaneseTrainerContext context)
    {
        if (context.Vocabularies.Any())
        {
            return; // Database has been seeded
        }

        var vocabularies = new Vocabulary[]
        {
            new Vocabulary { JapaneseWord = "こんにちは", Translation = "Hello" },
            new Vocabulary { JapaneseWord = "ありがとう", Translation = "Thank you" },
            new Vocabulary { JapaneseWord = "すみません", Translation = "Excuse me / I'm sorry" },
            new Vocabulary { JapaneseWord = "はい", Translation = "Yes" },
            new Vocabulary { JapaneseWord = "いいえ", Translation = "No" },
            new Vocabulary { JapaneseWord = "おはよう", Translation = "Good morning" },
            new Vocabulary { JapaneseWord = "こんばんは", Translation = "Good evening" },
            new Vocabulary { JapaneseWord = "さようなら", Translation = "Goodbye" },
            new Vocabulary { JapaneseWord = "お元気ですか", Translation = "How are you?" },
            new Vocabulary { JapaneseWord = "元気です", Translation = "I'm fine" },
            new Vocabulary { JapaneseWord = "水", Translation = "Water" },
            new Vocabulary { JapaneseWord = "食べ物", Translation = "Food" },
            new Vocabulary { JapaneseWord = "本", Translation = "Book" },
            new Vocabulary { JapaneseWord = "学校", Translation = "School" },
            new Vocabulary { JapaneseWord = "先生", Translation = "Teacher" }
        };

        context.Vocabularies.AddRange(vocabularies);
        context.SaveChanges();
    }
} 