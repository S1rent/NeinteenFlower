//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViewHistory.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionDetail
    {
        public int TransactionId { get; set; }
        public int FlowerId { get; set; }
        public int Quantity { get; set; }
    
        public virtual Flower Flower { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
