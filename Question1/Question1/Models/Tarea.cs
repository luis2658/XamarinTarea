using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Question1.Models
{    
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
