﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlueGrassDigital.Models.Admin
{
    public class PersonEdit
    {
        public string? FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressCountry { get; set; }

        public string AddressCity { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
    }
}
