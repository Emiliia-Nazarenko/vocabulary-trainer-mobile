using SQLite;
using System;

namespace VocabularyTrainer.Data
{
	public class Word
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[Unique(Name ="WordCombinedText", Order =1, Unique =true)]
		[Collation("NOCASE")]
		public string OriginalWord { get; set; }

		[Unique(Name = "WordCombinedText", Order = 2, Unique = true)]
		[Collation("NOCASE")]
		public string Translation { get; set; }

		public override string ToString()
		{
			return OriginalWord + " - " + Translation;
		}

		public bool Compare(Word word)
		{
			return this.OriginalWord.Equals(word.OriginalWord, StringComparison.OrdinalIgnoreCase) 
				&& this.Translation.Equals(word.Translation, StringComparison.OrdinalIgnoreCase);
		}
	}
}
