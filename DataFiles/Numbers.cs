//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel.DataFiles
{
    using System;
    using System.Collections.Generic;
    
    public partial class Numbers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Numbers()
        {
            this.Guests = new HashSet<Guests>();
            this.ReportStatusNumber = new HashSet<ReportStatusNumber>();
        }
    
        public int Id { get; set; }
        public Nullable<int> FloorId { get; set; }
        public Nullable<int> Number { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
        public virtual Categorys Categorys { get; set; }
        public virtual Floors Floors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Guests> Guests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportStatusNumber> ReportStatusNumber { get; set; }
    }
}
