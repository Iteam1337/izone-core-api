using System.ComponentModel.DataAnnotations.Schema;

namespace Izone.DB.Model
{
    [Table("people_db")]
    public class Person
    {
        [Column("p_id")]
        public int Id { get; set; }

        [Column("p_firstname")]
        public string Firstname { get; set; }

        [Column("p_lastname")]
        public string Lastname { get; set; }

        [Column("p_izusername")]
        public string IzoneUsername { get; set; }

        [Column("p_email")]
        public string Email { get; set; }
    }
}
