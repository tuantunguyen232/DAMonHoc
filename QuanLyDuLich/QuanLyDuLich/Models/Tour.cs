namespace QuanLyDuLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Comment = new HashSet<Comment>();
            Order_details = new HashSet<Order_details>();
            Schedule = new HashSet<Schedule>();
            Tour_image = new HashSet<Tour_image>();
            TourManagement = new HashSet<TourManagement>();
        }

        [Key]
        [StringLength(255)]
        public string id_tour { get; set; }

        [StringLength(100)]
        public string tour_name { get; set; }

        [StringLength(255)]
        public string tour_description { get; set; }

        public decimal? price { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public DateTime? departure_time { get; set; }

        public DateTime? return_time { get; set; }

        [StringLength(60)]
        public string departure_location { get; set; }

        [StringLength(60)]
        public string arrival_location { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rating { get; set; }

        public int? quantity { get; set; }

        public int? is_active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_details> Order_details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour_image> Tour_image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourManagement> TourManagement { get; set; }
    }
}
