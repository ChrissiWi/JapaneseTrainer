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

        var vocabularies = new List<Vocabulary>();
        
        // Add basic vocabulary
        vocabularies.AddRange(new Vocabulary[]
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
            new Vocabulary { JapaneseWord = "先生", Translation = "Teacher" },
            
            // New vocabulary words
            new Vocabulary { JapaneseWord = "朝", Translation = "Morning" },
            new Vocabulary { JapaneseWord = "夜", Translation = "Night" },
            new Vocabulary { JapaneseWord = "椅子", Translation = "Chair" },
            new Vocabulary { JapaneseWord = "お茶", Translation = "Tea" },
            new Vocabulary { JapaneseWord = "時計", Translation = "Clock" },
            new Vocabulary { JapaneseWord = "海", Translation = "Ocean" },
            new Vocabulary { JapaneseWord = "山", Translation = "Mountain" },
            new Vocabulary { JapaneseWord = "猫", Translation = "Cat" },
            new Vocabulary { JapaneseWord = "犬", Translation = "Dog" },
            new Vocabulary { JapaneseWord = "雑誌", Translation = "Magazine" },
            new Vocabulary { JapaneseWord = "机", Translation = "Desk" },
            new Vocabulary { JapaneseWord = "日本語", Translation = "Japanese (language)" }
        });

        // Add hiragana characters
        vocabularies.AddRange(GetHiraganaCharacters());

        context.Vocabularies.AddRange(vocabularies);
        context.SaveChanges();
    }

    private static List<Vocabulary> GetHiraganaCharacters()
    {
        return new List<Vocabulary>
        {
            // Basic vowels
            new Vocabulary { JapaneseWord = "あ", Translation = "a" },
            new Vocabulary { JapaneseWord = "い", Translation = "i" },
            new Vocabulary { JapaneseWord = "う", Translation = "u" },
            new Vocabulary { JapaneseWord = "え", Translation = "e" },
            new Vocabulary { JapaneseWord = "お", Translation = "o" },

            // K-column
            new Vocabulary { JapaneseWord = "か", Translation = "ka" },
            new Vocabulary { JapaneseWord = "き", Translation = "ki" },
            new Vocabulary { JapaneseWord = "く", Translation = "ku" },
            new Vocabulary { JapaneseWord = "け", Translation = "ke" },
            new Vocabulary { JapaneseWord = "こ", Translation = "ko" },

            // S-column
            new Vocabulary { JapaneseWord = "さ", Translation = "sa" },
            new Vocabulary { JapaneseWord = "し", Translation = "shi" },
            new Vocabulary { JapaneseWord = "す", Translation = "su" },
            new Vocabulary { JapaneseWord = "せ", Translation = "se" },
            new Vocabulary { JapaneseWord = "そ", Translation = "so" },

            // T-column
            new Vocabulary { JapaneseWord = "た", Translation = "ta" },
            new Vocabulary { JapaneseWord = "ち", Translation = "chi" },
            new Vocabulary { JapaneseWord = "つ", Translation = "tsu" },
            new Vocabulary { JapaneseWord = "て", Translation = "te" },
            new Vocabulary { JapaneseWord = "と", Translation = "to" },

            // N-column
            new Vocabulary { JapaneseWord = "な", Translation = "na" },
            new Vocabulary { JapaneseWord = "に", Translation = "ni" },
            new Vocabulary { JapaneseWord = "ぬ", Translation = "nu" },
            new Vocabulary { JapaneseWord = "ね", Translation = "ne" },
            new Vocabulary { JapaneseWord = "の", Translation = "no" },

            // H-column
            new Vocabulary { JapaneseWord = "は", Translation = "ha" },
            new Vocabulary { JapaneseWord = "ひ", Translation = "hi" },
            new Vocabulary { JapaneseWord = "ふ", Translation = "fu" },
            new Vocabulary { JapaneseWord = "へ", Translation = "he" },
            new Vocabulary { JapaneseWord = "ほ", Translation = "ho" },

            // M-column
            new Vocabulary { JapaneseWord = "ま", Translation = "ma" },
            new Vocabulary { JapaneseWord = "み", Translation = "mi" },
            new Vocabulary { JapaneseWord = "む", Translation = "mu" },
            new Vocabulary { JapaneseWord = "め", Translation = "me" },
            new Vocabulary { JapaneseWord = "も", Translation = "mo" },

            // Y-column
            new Vocabulary { JapaneseWord = "や", Translation = "ya" },
            new Vocabulary { JapaneseWord = "ゆ", Translation = "yu" },
            new Vocabulary { JapaneseWord = "よ", Translation = "yo" },

            // R-column
            new Vocabulary { JapaneseWord = "ら", Translation = "ra" },
            new Vocabulary { JapaneseWord = "り", Translation = "ri" },
            new Vocabulary { JapaneseWord = "る", Translation = "ru" },
            new Vocabulary { JapaneseWord = "れ", Translation = "re" },
            new Vocabulary { JapaneseWord = "ろ", Translation = "ro" },

            // W-column
            new Vocabulary { JapaneseWord = "わ", Translation = "wa" },
            new Vocabulary { JapaneseWord = "を", Translation = "wo" },

            // N
            new Vocabulary { JapaneseWord = "ん", Translation = "n" },

            // Dakuten (voiced sounds)
            new Vocabulary { JapaneseWord = "が", Translation = "ga" },
            new Vocabulary { JapaneseWord = "ぎ", Translation = "gi" },
            new Vocabulary { JapaneseWord = "ぐ", Translation = "gu" },
            new Vocabulary { JapaneseWord = "げ", Translation = "ge" },
            new Vocabulary { JapaneseWord = "ご", Translation = "go" },

            new Vocabulary { JapaneseWord = "ざ", Translation = "za" },
            new Vocabulary { JapaneseWord = "じ", Translation = "ji" },
            new Vocabulary { JapaneseWord = "ず", Translation = "zu" },
            new Vocabulary { JapaneseWord = "ぜ", Translation = "ze" },
            new Vocabulary { JapaneseWord = "ぞ", Translation = "zo" },

            new Vocabulary { JapaneseWord = "だ", Translation = "da" },
            new Vocabulary { JapaneseWord = "ぢ", Translation = "ji" },
            new Vocabulary { JapaneseWord = "づ", Translation = "zu" },
            new Vocabulary { JapaneseWord = "で", Translation = "de" },
            new Vocabulary { JapaneseWord = "ど", Translation = "do" },

            new Vocabulary { JapaneseWord = "ば", Translation = "ba" },
            new Vocabulary { JapaneseWord = "び", Translation = "bi" },
            new Vocabulary { JapaneseWord = "ぶ", Translation = "bu" },
            new Vocabulary { JapaneseWord = "べ", Translation = "be" },
            new Vocabulary { JapaneseWord = "ぼ", Translation = "bo" },

            // Handakuten (semi-voiced sounds)
            new Vocabulary { JapaneseWord = "ぱ", Translation = "pa" },
            new Vocabulary { JapaneseWord = "ぴ", Translation = "pi" },
            new Vocabulary { JapaneseWord = "ぷ", Translation = "pu" },
            new Vocabulary { JapaneseWord = "ぺ", Translation = "pe" },
            new Vocabulary { JapaneseWord = "ぽ", Translation = "po" },

            // Small characters
            new Vocabulary { JapaneseWord = "ぁ", Translation = "a" },
            new Vocabulary { JapaneseWord = "ぃ", Translation = "i" },
            new Vocabulary { JapaneseWord = "ぅ", Translation = "u" },
            new Vocabulary { JapaneseWord = "ぇ", Translation = "e" },
            new Vocabulary { JapaneseWord = "ぉ", Translation = "o" },
            new Vocabulary { JapaneseWord = "っ", Translation = "tsu" },
            new Vocabulary { JapaneseWord = "ゃ", Translation = "ya" },
            new Vocabulary { JapaneseWord = "ゅ", Translation = "yu" },
            new Vocabulary { JapaneseWord = "ょ", Translation = "yo" }
        };
    }
} 