﻿using System;

namespace SelfJournal.Database.EF
{
    public class Goal
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}