﻿using ReadIt.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReadIt.Models
{
    public class Note
    {
        public Note(string title, string text)
        {
            Title = title;
            Text = text;
        }


        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        
        
        [ForeignKey("User")]

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
