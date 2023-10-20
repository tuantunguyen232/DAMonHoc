namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Comment = new HashSet<Comment>();
            Order = new HashSet<Order>();
            TourManagement = new HashSet<TourManagement>();
        }

        [Key]
        public int id_user { get; set; }

        [StringLength(20)]
        public string first_name { get; set; }

        [StringLength(20)]
        public string last_name { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        [StringLength(20)]
        public string user_role { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourManagement> TourManagement { get; set; }
    }
}
