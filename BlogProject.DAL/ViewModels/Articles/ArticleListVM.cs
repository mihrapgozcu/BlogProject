using BlogProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Articles
{
    //Komutları yazalım istenenler
    public class ArticleListVM
    {
        public List<Article> Articles { get; set; }

        public int CategoryId { get; set; }

        //aşağıda sayfa numaraları çıkacak ve current page hiçbir şey seçili olmadan default seçili gelen sayfa numarası.
        public virtual int CurrentPage { get; set; } = 1;

        //sayfada kaç tane makale bloğu göstermek istiyoruz.
        public virtual int PageSize { get; set; } = 3;

        //toplam makale sayısı
        public virtual int TotalCount { get; set; }

        //aşağıda kaç sayfa göstermek istiyoruz. Ceiling => Ondalıklı sayıyı ondalık kısmına bakmaksızın bir üst sayıya yuvarlar. (toplam makale sayısı / sayfada gösterilen makale sayısı = TotalPages)
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));

        //önceki sayfayı göster. seçili sayfa 1'den büyükse göster.
        public virtual bool ShowPrevious => CurrentPage > 1;

        //sonraki sayfayı göster. seçili sayfa toplam sayfadan küçükse göster.
        public virtual bool ShowNext => CurrentPage < TotalPages;

        public virtual bool IsAscending { get; set; } = false;
    }
}
