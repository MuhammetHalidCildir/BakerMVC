using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Urunler
{
    [Table("altkategori")]
    public class AltKategori : BaseEntity
    {
        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<Urun> Urunler { get; set; }

    }
}
