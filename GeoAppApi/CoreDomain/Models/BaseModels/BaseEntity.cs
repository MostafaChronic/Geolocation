using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreDomain.Models.BaseModels
{

    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }


    }
}
