using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MovieTicketBookingApp.Models
{
    public class Movie
    {
        // User ID is the Primary Key 
        [Key] // DataAnnotations used to declare that it is a primary key.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Creating a Auto incremented ID - sql example(Identity(1,1))
        [Column(TypeName = "int")]
        [Required]
        public int MovieID { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        [Required]
        public string ImgLink { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Duration { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        [Required]
        public string Language { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "nvarchar(36)")]
        [Required]
        public string Censorship { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string Country { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string TrailerLink { get; set; }

        

    }
}
