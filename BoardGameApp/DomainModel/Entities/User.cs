﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
