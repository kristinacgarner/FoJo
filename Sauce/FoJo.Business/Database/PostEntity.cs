using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FoJo.Business.Database
{
    public class PostEntity : EntityBase
    {
        public DateTime? PublishDate { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public string PostedById { get; set; }
        public IdentityUser PostedBy { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public List<AttachmentEntity> Attachments { get; set; }
    }
}