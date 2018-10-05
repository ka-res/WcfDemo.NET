﻿using System.ComponentModel.DataAnnotations;
using WcfDemo.Contracts;

namespace WcfServiceDemo.DataModels
{
    public class ContactModel : Contact
    {
        [Key]
        public int Id { get; set; }
    }
}