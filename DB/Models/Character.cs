using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Character 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        public string Gender { get; set; }
        public string OriginName { get; set; }
        public string OriginURL { get; set; }
        public string LocationName { get; set; }
        public string LocationURL { get; set; }

        public string Image { get; set; }

       // public List<string> Episode { get; set; }

        public string URL { get; set; }

        public DateTime Created { get; set; }

    }
}
