namespace WFA.APPID.BookService.ServiceHost.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class OrderDetail
    {
        public int Id { get; set; }

        public int? OrderID { get; set; }

        public int? BookID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}
