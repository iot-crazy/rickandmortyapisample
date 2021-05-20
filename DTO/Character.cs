using System;
using System.Collections.Generic;

namespace DTO
{
    public sealed class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public string Gender { get; set; }
        public Location Origin { get; set; }
        public Location Location { get; set; }

        public string Image { get; set; }

        public List<string> Episode { get; set; }

        public string URL { get; set; }

        public DateTime Created { get; set; }
    }
}
