﻿using System.ComponentModel.DataAnnotations;
using WcfDemo.Common.Interfaces;

namespace WcfServiceDemo.DataModels
{
    public class ContactTypeModel : IEnumDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}