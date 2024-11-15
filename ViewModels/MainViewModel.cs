﻿using ALDSemestral.Models;
using System;
using System.Collections.Generic;
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

        private Dictionary<string, Image> tiles;

        public MainViewModel()
        {
            tiles = new Dictionary<string, Image>();
            for (int i = 0; i < 16; i++) {
                var key = Convert.ToString(i, 2).PadLeft(4, '0');
                tiles.Add(key, new Image() { Path = $"../Resources/{key}.png" });
            }

            NRowsInput = 15;
            NColumnsInput = 15;

            GenerateComm = new RelayCommand(() => Render(), () => true);

            Render();
        }

        private void Render()
        {
            ImageGrid = new ObservableCollection<Image>();

            if (NRowsInput < 2) NRowsInput = 2;
            if (NRowsInput > 50) NRowsInput = 50;
            if (NColumnsInput < 2) NColumnsInput = 2;
            if (NColumnsInput > 50) NColumnsInput = 50;

            NRows = NRowsInput;
            NColumns = NColumnsInput;

            Generator.Generate(NColumns, NRows);

            for (int i = 0; i < NRows; i++)
            {
                for (int y = 0; y < NColumns; y++)
                {
                    ImageGrid.Add(tiles[Generator.array![y, i]]);
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
