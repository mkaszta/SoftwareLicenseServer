using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareLicenseServer.Models
{
    public class LicensingModels
    {
        public class Apps
        {
            [Key]
            public int App_Id { get; set; }
            [StringLength(100)]
            public string App_Name { get; set; }
            [StringLength(50)]
            public string App_Acronym { get; set; }
            [StringLength(20)]
            public string App_Version { get; set; }
        }
        public class Contractors
        {
            [Key]
            public int Ctr_Id { get; set; }
            [StringLength(100)]
            public string Ctr_CompanyName { get; set; }
            [StringLength(15)]
            public string Ctr_NIP { get; set; }
            [StringLength(100)]
            public string Ctr_Email { get; set; }
        }
        public class Licenses
        {
            [Key]
            public int Lic_Id { get; set; }
            public int Ctr_Id { get; set; }
            public int App_Id { get; set; }
            [StringLength(128)]
            public string Lic_Key { get; set; }
            public int Lic_ActivationStatus { get; set; }
            public DateTime Lic_ActivationDate { get; set; }
            public DateTime Lic_ExpirationDate { get; set; }

            public virtual Contractors Contractors { get; set; }
            public virtual Apps Apps { get; set; }
        }

        public class Sessions
        {
            [Key]
            public int Ses_Id { get; set; }
            public int Ctr_Id { get; set; }
            public int App_id { get; set; }
            public DateTime Ses_StartDate { get; set; }
            public DateTime Ses_ExpirationDate { get; set; }
            public DateTime Ses_EndDate { get; set; }

            public virtual Contractors Contractors { get; set; }
            public virtual Apps Apps { get; set; }
        }
    }
}