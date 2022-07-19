using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    //Ürün listesinin bir tanesinin modeli
    public class UrunListItem
    {
        [Display(Name = "Kimliği")]
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Title { get; set; }
        [Display(Name = "Alt Kategorisi")]
        public string Altkategori { get; set; }
        [Display(Name = "Kategorisi")]
        public string Kategori { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }

    //Ürün detay modeli
    public class UrunDetail
    {
        [Display(Name = "Kimliği")]
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required]
        [MinLength(5), MaxLength(150)]
        public string Title { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [Required]
        [MinLength(5), MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Alt Kategori")]
        [Required]
        public int AltkategoriId { get; set; }

        [Display(Name = "Fiyat")]
        [Required]
        public decimal Fiyat { get; set; }

        [Display(Name = "Kampanyalı mı?")]
        public bool Kampanya { get; set; }

        [Display(Name = "Kampanya Oranı")]
        public int KampanyaOrani { get; set; }
    }

    public class AltKategoriViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int KategoriId { get; set; }
    }
    public class KategoriViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
