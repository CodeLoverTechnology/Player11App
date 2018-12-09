//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P11WebAPI.P11DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class T_RunningMatchInfo
    {
        public int ID { get; set; }
        public int MatchID { get; set; }
        [Display(Name = "Running Match Details:")]
        [AllowHtml]
        public string MatchDescription { get; set; }
        [AllowHtml]
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual M_MatchInfoMaters M_MatchInfoMaters { get; set; }
    }
}
