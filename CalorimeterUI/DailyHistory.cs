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
    
    public partial class DailyHistory
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Calories { get; set; }
        public string HistoryId { get; set; }
    
        public virtual History History { get; set; }
    }
}
