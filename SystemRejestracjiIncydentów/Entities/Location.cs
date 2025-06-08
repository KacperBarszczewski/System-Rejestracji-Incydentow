﻿using SystemRejestracjiIncydentów.Enums;

namespace SystemRejestracjiIncydentów.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public LocationStatus Status { get; set; }
    }
}
