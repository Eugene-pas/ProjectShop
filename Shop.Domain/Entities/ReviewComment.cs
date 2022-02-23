﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class ReviewComment : EntityBase
    {
        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Review Review { get; set; }

        public virtual Customer Customer { get; set; }
    }
}