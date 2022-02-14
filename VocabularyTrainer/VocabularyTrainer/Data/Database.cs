using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VocabularyTrainer.Data
{
	public class Database
	{
		readonly SQLiteAsyncConnection _database;

		#region Events

		public event EventHandler WordsUpdated;

		#endregion Events

		#region Constructor

		public Database(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Word>().Wait();
		}

		#endregion Constructor

		#region Public Methods

		public async Task<List<Word>> GetWordsAsync()
		{
			return await _database.Table<Word>().ToListAsync().ConfigureAwait(false);
		}

		public async Task<int> SaveWordAsync(Word word)
		{
			var result = await _database.InsertAsync(word).ConfigureAwait(false);
			if (WordsUpdated is not null)
				WordsUpdated(this, new EventArgs());
			return result;
		}

		public async Task DeleteWordAsync(int id)
		{
			await _database.DeleteAsync(id).ConfigureAwait(false);
			if (WordsUpdated is not null)
				WordsUpdated(this, new EventArgs());
		}

		public async Task UpdateWordAsync(Word word)
		{
			await _database.UpdateAsync(word).ConfigureAwait(false);
			if (WordsUpdated is not null)
				WordsUpdated(this, new EventArgs());
		}

		#endregion Public Methods
	}
}
