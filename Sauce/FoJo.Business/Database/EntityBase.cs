using System;
using System.ComponentModel.DataAnnotations;

namespace FoJo.Business.Database
{
    public abstract class EntityBase
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}