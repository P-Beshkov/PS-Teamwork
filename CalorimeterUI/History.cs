//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorimeterUI
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public History()
        {
            this.DailyHistory = new HashSet<DailyHistory>();
        }
    
        public int Id { get; set; }
        public string Data { get; set; }
        public decimal DailyCalories { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<DailyHistory> DailyHistory { get; set; }
        public virtual Users Users { get; set; }
    }
}
