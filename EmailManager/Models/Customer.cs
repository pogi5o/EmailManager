using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmailManager.Models {
    [Table("email_ref")]
    public class Customer {
        [Column("CUSTOMER_NO")]
        [Key]
        [Display(Name ="Customer Number")]
        [Required(ErrorMessage="Customer Number is required")]
        public string CustomerNo { get; set; }
        
        [Column("COMPANY_NAME")]
        [Display(Name ="Company Name")]
        [Required(ErrorMessage ="Company Name is required")]
        public string CompanyName { get; set; }

        [Column("Z_REPORT_DIST")]
        [Display(Name ="Distribution List")]
        [Required(ErrorMessage ="Email distribution is required")]
        public string Emails { get; set; }

    }
}
