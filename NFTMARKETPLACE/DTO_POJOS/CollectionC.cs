﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_POJOS
{
    public class CollectionC : BaseEntity
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompanyId { get; set; }
        public string CategoryName { get; set; }
    }
}