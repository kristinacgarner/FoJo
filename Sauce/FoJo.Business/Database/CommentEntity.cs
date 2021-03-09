using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoJo.Business.Database
{
    public class CommentEntity : EntityBase
    {
        [Required]
        public DateTime PostDate { get; set; } = DateTime.Now;

        [Required]
        public string Content { get; set; }

        [Required]
        public string PostedById { get; set; }
        public IdentityUser PostedBy { get; set; }
       
        [Required]
        public string PostId { get; set; }
        public PostEntity Post { get; set; }
    }
}