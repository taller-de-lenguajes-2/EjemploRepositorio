using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2.Models
{
    public class Director
    {
        private string name;
        private int id;
        private int gender;
        private int uid;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int Gender { get => gender; set => gender = value; }
        public int Uid { get => uid; set => uid = value; }
    }
}