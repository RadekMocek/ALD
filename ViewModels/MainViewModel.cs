using ALDSemestral.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ALDSemestral.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int nRowsInput;
        public int NRowsInput { get => nRowsInput; set { nRowsInput = value; NotifyPropertyChanged(); } }

        private int nColumnsInput;
        public int NColumnsInput { get => nColumnsInput; set { nColumnsInput = value; NotifyPropertyChanged(); } }

        private int nRows;
        public int NRows { get => nRows; set { nRows = value; NotifyPropertyChanged(); } }

        private int nColumns;
        public int NColumns { get => nColumns; set { nColumns = value; NotifyPropertyChanged(); } }

        private ObservableCollection<Image>? imageGrid;
        public ObservableCollection<Image>? ImageGrid { get => imageGrid; set { imageGrid = value; NotifyPropertyChanged(); } }

        public RelayCommand GenerateComm { get; set; }

        public MainViewModel()
        {
            NRowsInput = 5;
            NColumnsInput = 5;

            GenerateComm = new RelayCommand(() => Render(), () => true);

            Render();
        }

        private void Render()
        {
            ImageGrid = new ObservableCollection<Image>();
            NRows = NRowsInput;
            NColumns = NColumnsInput;

            Generator.Generate(NColumns, NRows);
            for (int i = 0; i < NRows; i++)
            {
                for (int y = 0; y < NColumns; y++)
                {
                    ImageGrid.Add(new Image() { Path = $"../Resources/TestingTile{Generator.array![i, y]}.png" });
                }

            }
        }

        #region INotifyPropertyChanged essentials
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
