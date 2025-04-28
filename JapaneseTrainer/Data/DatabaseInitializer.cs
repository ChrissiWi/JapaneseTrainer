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
            new Vocabulary { JapaneseWord = "おはようございます", Translation = "Good morning (formal)" },
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
            new Vocabulary { JapaneseWord = "日本語", Translation = "Japanese (language)" },
            
            // Additional vocabulary words
            new Vocabulary { JapaneseWord = "野菜", Translation = "Vegetables" },
            new Vocabulary { JapaneseWord = "魚", Translation = "Fish" },
            new Vocabulary { JapaneseWord = "卵", Translation = "Egg" },
            new Vocabulary { JapaneseWord = "家族", Translation = "Family" },
            new Vocabulary { JapaneseWord = "空", Translation = "Sky" }
        });

        // Add hiragana and katakana characters
        vocabularies.AddRange(GetHiraganaCharacters());
        vocabularies.AddRange(GetKatakanaCharacters());

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

    private static List<Vocabulary> GetKatakanaCharacters()
    {
        return new List<Vocabulary>
        {
            // Basic vowels
            new Vocabulary { JapaneseWord = "ア", Translation = "a" },
            new Vocabulary { JapaneseWord = "イ", Translation = "i" },
            new Vocabulary { JapaneseWord = "ウ", Translation = "u" },
            new Vocabulary { JapaneseWord = "エ", Translation = "e" },
            new Vocabulary { JapaneseWord = "オ", Translation = "o" },

            // K-column
            new Vocabulary { JapaneseWord = "カ", Translation = "ka" },
            new Vocabulary { JapaneseWord = "キ", Translation = "ki" },
            new Vocabulary { JapaneseWord = "ク", Translation = "ku" },
            new Vocabulary { JapaneseWord = "ケ", Translation = "ke" },
            new Vocabulary { JapaneseWord = "コ", Translation = "ko" },

            // S-column
            new Vocabulary { JapaneseWord = "サ", Translation = "sa" },
            new Vocabulary { JapaneseWord = "シ", Translation = "shi" },
            new Vocabulary { JapaneseWord = "ス", Translation = "su" },
            new Vocabulary { JapaneseWord = "セ", Translation = "se" },
            new Vocabulary { JapaneseWord = "ソ", Translation = "so" },

            // T-column
            new Vocabulary { JapaneseWord = "タ", Translation = "ta" },
            new Vocabulary { JapaneseWord = "チ", Translation = "chi" },
            new Vocabulary { JapaneseWord = "ツ", Translation = "tsu" },
            new Vocabulary { JapaneseWord = "テ", Translation = "te" },
            new Vocabulary { JapaneseWord = "ト", Translation = "to" },

            // N-column
            new Vocabulary { JapaneseWord = "ナ", Translation = "na" },
            new Vocabulary { JapaneseWord = "ニ", Translation = "ni" },
            new Vocabulary { JapaneseWord = "ヌ", Translation = "nu" },
            new Vocabulary { JapaneseWord = "ネ", Translation = "ne" },
            new Vocabulary { JapaneseWord = "ノ", Translation = "no" },

            // H-column
            new Vocabulary { JapaneseWord = "ハ", Translation = "ha" },
            new Vocabulary { JapaneseWord = "ヒ", Translation = "hi" },
            new Vocabulary { JapaneseWord = "フ", Translation = "fu" },
            new Vocabulary { JapaneseWord = "ヘ", Translation = "he" },
            new Vocabulary { JapaneseWord = "ホ", Translation = "ho" },

            // M-column
            new Vocabulary { JapaneseWord = "マ", Translation = "ma" },
            new Vocabulary { JapaneseWord = "ミ", Translation = "mi" },
            new Vocabulary { JapaneseWord = "ム", Translation = "mu" },
            new Vocabulary { JapaneseWord = "メ", Translation = "me" },
            new Vocabulary { JapaneseWord = "モ", Translation = "mo" },

            // Y-column
            new Vocabulary { JapaneseWord = "ヤ", Translation = "ya" },
            new Vocabulary { JapaneseWord = "ユ", Translation = "yu" },
            new Vocabulary { JapaneseWord = "ヨ", Translation = "yo" },

            // R-column
            new Vocabulary { JapaneseWord = "ラ", Translation = "ra" },
            new Vocabulary { JapaneseWord = "リ", Translation = "ri" },
            new Vocabulary { JapaneseWord = "ル", Translation = "ru" },
            new Vocabulary { JapaneseWord = "レ", Translation = "re" },
            new Vocabulary { JapaneseWord = "ロ", Translation = "ro" },

            // W-column
            new Vocabulary { JapaneseWord = "ワ", Translation = "wa" },
            new Vocabulary { JapaneseWord = "ヲ", Translation = "wo" },

            // N
            new Vocabulary { JapaneseWord = "ン", Translation = "n" },

            // Dakuten (voiced sounds)
            new Vocabulary { JapaneseWord = "ガ", Translation = "ga" },
            new Vocabulary { JapaneseWord = "ギ", Translation = "gi" },
            new Vocabulary { JapaneseWord = "グ", Translation = "gu" },
            new Vocabulary { JapaneseWord = "ゲ", Translation = "ge" },
            new Vocabulary { JapaneseWord = "ゴ", Translation = "go" },

            new Vocabulary { JapaneseWord = "ザ", Translation = "za" },
            new Vocabulary { JapaneseWord = "ジ", Translation = "ji" },
            new Vocabulary { JapaneseWord = "ズ", Translation = "zu" },
            new Vocabulary { JapaneseWord = "ゼ", Translation = "ze" },
            new Vocabulary { JapaneseWord = "ゾ", Translation = "zo" },

            new Vocabulary { JapaneseWord = "ダ", Translation = "da" },
            new Vocabulary { JapaneseWord = "ヂ", Translation = "ji" },
            new Vocabulary { JapaneseWord = "ヅ", Translation = "zu" },
            new Vocabulary { JapaneseWord = "デ", Translation = "de" },
            new Vocabulary { JapaneseWord = "ド", Translation = "do" },

            new Vocabulary { JapaneseWord = "バ", Translation = "ba" },
            new Vocabulary { JapaneseWord = "ビ", Translation = "bi" },
            new Vocabulary { JapaneseWord = "ブ", Translation = "bu" },
            new Vocabulary { JapaneseWord = "ベ", Translation = "be" },
            new Vocabulary { JapaneseWord = "ボ", Translation = "bo" },

            // Handakuten (semi-voiced sounds)
            new Vocabulary { JapaneseWord = "パ", Translation = "pa" },
            new Vocabulary { JapaneseWord = "ピ", Translation = "pi" },
            new Vocabulary { JapaneseWord = "プ", Translation = "pu" },
            new Vocabulary { JapaneseWord = "ペ", Translation = "pe" },
            new Vocabulary { JapaneseWord = "ポ", Translation = "po" },

            // Small characters
            new Vocabulary { JapaneseWord = "ァ", Translation = "a" },
            new Vocabulary { JapaneseWord = "ィ", Translation = "i" },
            new Vocabulary { JapaneseWord = "ゥ", Translation = "u" },
            new Vocabulary { JapaneseWord = "ェ", Translation = "e" },
            new Vocabulary { JapaneseWord = "ォ", Translation = "o" },
            new Vocabulary { JapaneseWord = "ッ", Translation = "tsu" },
            new Vocabulary { JapaneseWord = "ャ", Translation = "ya" },
            new Vocabulary { JapaneseWord = "ュ", Translation = "yu" },
            new Vocabulary { JapaneseWord = "ョ", Translation = "yo" }
        };
    }
} 