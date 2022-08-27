//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Block
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Block()
        {
            this.Clusters = new HashSet<Cluster>();
        }
    
        public int BlockID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> DistrictCode { get; set; }
        public string BlockName { get; set; }
        public string AlternateBlockName { get; set; }
        public Nullable<int> BlockCode { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual District District { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cluster> Clusters { get; set; }
    }
}
