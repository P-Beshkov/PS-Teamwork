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
    
    public partial class DailyHistory
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> Calories { get; set; }
        public int HistoryId { get; set; }
    
        public virtual History History { get; set; }
    }
}
