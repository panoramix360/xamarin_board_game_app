﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace DomainModel.Entities
{
    public class BoardGame : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        private int _gameId;
        [Key]
        public int GameId
        {
            get => _gameId;
            set => SetPropertyAndNotify(ref _gameId, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetPropertyAndNotify(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetPropertyAndNotify(ref _description, value);
        }

        private int _yearPublished;
        public int YearPublished
        {
            get => _yearPublished;
            set => SetPropertyAndNotify(ref _yearPublished, value);
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set => SetPropertyAndNotify(ref _imageUrl, value);
        }

        private string _thumbnailUrl;
        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set => SetPropertyAndNotify(ref _thumbnailUrl, value);
        }

        public string PlayersRange
        {
            get => "Jogadores: " + _minPlayers + " - " + _maxPlayers;
        }

        private int _minPlayers;
        public int MinPlayers
        {
            get => _minPlayers;
            set => SetPropertyAndNotify(ref _minPlayers, value);
        }

        private int _maxPlayers;
        public int MaxPlayers
        {
            get => _maxPlayers;
            set => SetPropertyAndNotify(ref _maxPlayers, value);
        }

        public string PlayingTimeString
        {
            get => _playingTime + " minutos";
        }

        private int _playingTime;
        public int PlayingTime
        {
            get => _playingTime;
            set => SetPropertyAndNotify(ref _playingTime, value);
        }

        private bool _isExpansion;
        public bool IsExpansion
        {
            get => _isExpansion;
            set => SetPropertyAndNotify(ref _isExpansion, value);
        }

        private double _averageRating;
        public double AverageRating
        {
            get => _averageRating;
            set => SetPropertyAndNotify(ref _averageRating, value);
        }

        private int _rank;
        public int Rank
        {
            get => _rank;
            set => SetPropertyAndNotify(ref _rank, value);
        }

        private int _numPlays;
        public int NumPlays
        {
            get => _numPlays;
            set => SetPropertyAndNotify(ref _numPlays, value);
        }

        private bool _owned;
        public bool Owned
        {
            get => _owned;
            set => SetPropertyAndNotify(ref _owned, value);
        }

        public BoardGame()
        {
        }

        [JsonConstructor]
        public BoardGame(int _gameId,
                            string _name,
                            string _imageUrl,
                            string _imageThumbnail,
                            int _minPlayers,
                            int _maxPlayers,
                            int _playingTime,
                            bool _isExpansion,
                            double _averageRating,
                            int _rank,
                            int _numPlays,
                            bool _owned,
                            string _description = "",
                            int _yearPublished = 0)
        {
            Id = Guid.NewGuid();
            GameId = _gameId;
            Name = _name ?? string.Empty;
            Description = _description ?? string.Empty;
            YearPublished = _yearPublished;
            ImageUrl = _imageUrl ?? string.Empty;
            ThumbnailUrl = _imageThumbnail ?? string.Empty;
            MinPlayers = _minPlayers;
            MaxPlayers = _maxPlayers;
            PlayingTime = _playingTime;
            IsExpansion = _isExpansion;
            AverageRating = _averageRating;
            Rank = _rank;
            NumPlays = _numPlays;
            Owned = _owned;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Dispara notificação apenas se o valor de uma propriedade foi alterada.
        /// </summary>
        /// <typeparam name="T">Tipo da propriedade</typeparam>
        /// <param name="variable">Referencia </param>
        /// <param name="value">Valor a ser atribuido.</param>
        /// <param name="propertyNames">Nome da propriedade para notificar os listeners.  
        /// Nome da propriedade para notificar os listeners.  
        /// Esse valor é opcional porque será preenchido pelo compilador através do CallerMemberName.</param>
        /// <returns>Retorna TRUE se o valor foi alterado.</returns>
        protected bool SetPropertyAndNotify<T>(ref T variable, T value, [CallerMemberName]string propertyName = null)
        {
            if (object.Equals(variable, value))
                return false;

            variable = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifica aos listeners que uma determinada propriedade mudou..
        /// </summary>
        /// <param name="propertyNames">Nome da propriedade para notificar os listeners.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
