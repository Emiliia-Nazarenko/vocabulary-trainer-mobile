using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VocabularyTrainer.Models;
using VocabularyTrainer.Services;
using Xamarin.Forms;

namespace VocabularyTrainer.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
		private readonly Dictionary<string, object> _propertyValues = new Dictionary<string, object>();


		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		string title = string.Empty;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		protected bool SetProperty<T>(ref T backingStore, T value,
			[CallerMemberName] string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		protected T GetValue<T>([CallerMemberName] string propertyName = "")
		{
			return _propertyValues.TryGetValue(propertyName, out var value) ? (T)value : default;
		}

		protected void SetValue(object value, [CallerMemberName] string propertyName = "")
		{
			_propertyValues[propertyName] = value;
			var changed = PropertyChanged;
			if (changed == null)
				return;
			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;
			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion	

	}
}
