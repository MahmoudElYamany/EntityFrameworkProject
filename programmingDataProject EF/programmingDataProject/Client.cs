//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace programmingDataProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public int Recipt_ID { get; set; }
        public int item_id { get; set; }
        public int storage_id { get; set; }
        public string date { get; set; }
        public string custumer_id { get; set; }
        public int amount { get; set; }
        public Nullable<double> selling_Price { get; set; }
        public Nullable<double> Tax { get; set; }
    
        public virtual Customers_Suppliers Customers_Suppliers { get; set; }
        public virtual item item { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
