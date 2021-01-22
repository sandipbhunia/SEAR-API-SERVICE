namespace WFA.APPID.BookService.ServiceHost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 
    public partial class Review
    {
        public int ReviewID { get; set; }

        public int BookID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }

        public virtual Book Book { get; set; }
    }
}
