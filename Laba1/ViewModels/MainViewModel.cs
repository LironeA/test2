using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Laba1.Classes;
using Laba1.Classes.Helpers;
using Laba1.Classes.Services;
using Laba1.Models;
using Microsoft.Maui.Controls;
using System.Linq;
using System.IO;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
using System.Threading;
using CommunityToolkit.Maui.Storage;

namespace Laba1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FileService _fileService;
        private readonly SortManager _sortManager;

        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private string _newArrayInput;
        public string NewArrayInput
        {
            get => _newArrayInput;
            set
            {
                _newArrayInput = value;
                OnPropertyChanged(nameof(NewArrayInput));
            }
        }

        public ICommand ShowHistogramPageCommand { get; }
        public ICommand OpenFileCommand { get; }
        public ICommand CreateFileCommand { get; }

        private int[] _initialArray;
        private int[] _sortedArray;

        public MainViewModel()
        {
            _fileService = new FileService();
            _sortManager = new SortManager();

            ShowHistogramPageCommand = new Command(async () => await ShowHistogramPage());
            OpenFileCommand = new Command(async () => await OpenFile());
            CreateFileCommand = new Command(async () => await CreateFile());
        }

        private async Task ShowHistogramPage()
        {
            if (_initialArray == null || _sortedArray == null)
            {
                await Application.Current.MainPage.DisplayAlert("Помилка", "Спочатку виконайте сортування.", "OK");
                return;
            }

            string initial = string.Join(",", _initialArray);
            string sorted = string.Join(",", _sortedArray);

            await Shell.Current.GoToAsync($"HistogramPage?initialArray={Uri.EscapeDataString(initial)}&sortedArray={Uri.EscapeDataString(sorted)}");
        }

        private async Task OpenFile()
        {
            try
            {
                var fileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.text" } },
                    { DevicePlatform.Android, new[] { "text/plain" } },
                    { DevicePlatform.WinUI, new[] { ".txt" } },
                    { DevicePlatform.macOS, new[] { "txt" } },
                });

                var file = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = fileType,
                    PickerTitle = "Виберіть текстовий файл з числами"
                });

                if (file != null)
                {
                    _initialArray = await _fileService.ReadIntArrayFromFileAsync(file);
                    var results = _sortManager.SortAll(_initialArray);
                    var mostEfficient = _sortManager.GetMostEfficient(_initialArray);

                    // Assuming all sorted arrays are identical, pick first
                    _sortedArray = results.FirstOrDefault()?.SortedArray;

                    Result = string.Join("\n", results.Select(r => $"{r.AlgorithmName}: {r.Iterations} ітерацій")) +
                             $"\n\nНайефективніший алгоритм: {mostEfficient?.AlgorithmName}";
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Помилка", ex.Message, "OK");
            }
        }

        private async Task CreateFile()
        {
            try
            {
                string input = NewArrayInput;
                if (string.IsNullOrWhiteSpace(input))

                {
                    await Application.Current.MainPage.DisplayAlert("Помилка", "Введіть числа.", "OK");
                    return;
                }

                if (!input.TryParseArray(out int[] integers))
                {
                    await Application.Current.MainPage.DisplayAlert("Помилка", "Введені дані містять нецілі числа.", "OK");
                    return;
                }

                // Збереження файлу

                var folderPickerResult = await FolderPicker.Default.PickAsync();


                string filePath = Path.Combine(folderPickerResult.Folder.Path, "user_array.txt");
                await _fileService.SaveIntArrayToFileAsync(integers, filePath);
                await Application.Current.MainPage.DisplayAlert("Успіх", $"Файл збережено за адресою:\n{filePath}", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Помилка", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
