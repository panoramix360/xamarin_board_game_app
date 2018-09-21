﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DomainModel.Entities
{
    public class BoardGame : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        private int _gameId;
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


        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set => SetPropertyAndNotify(ref _imageUrl, value);
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

        public BoardGame(int gameId,
                            string name,
                            string imageUrl,
                            int minPlayers,
                            int maxPlayers,
                            int playingTime,
                            bool isExpansion,
                            double averageRating,
                            int rank,
                            int numPlays,
                            bool owned)
        {
            Id = Guid.NewGuid();
            GameId = gameId;
            Name = name ?? string.Empty;
            ImageUrl = imageUrl ?? string.Empty;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            PlayingTime = playingTime;
            IsExpansion = isExpansion;
            AverageRating = averageRating;
            Rank = rank;
            NumPlays = numPlays;
            Owned = owned;
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
