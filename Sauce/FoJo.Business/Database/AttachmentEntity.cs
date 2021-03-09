using System;
using System.ComponentModel.DataAnnotations;

namespace FoJo.Business.Database
{
    public class AttachmentEntity : EntityBase
    {
        [Required]
        public Guid FileId { get;  set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public string PostId { get; set; }
        public PostEntity Post { get; set; }
    }
}