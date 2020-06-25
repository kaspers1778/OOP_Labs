using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_6.Models
{
    class Contract
    {
        public int ContractId { get; set; }
        public int RegistrationNumber { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public Brocker Broker { get; set; }
        public Client Client { get; set; }
        public Estate Estate { get; set; }
    }
}
