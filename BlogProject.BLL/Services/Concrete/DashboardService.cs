using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IArticleRepository _articleRepo;
        private readonly ICategoryRepository _categoryRepo;

        public DashboardService(IArticleRepository articleRepo, ICategoryRepository categoryRepo)
        {
            _articleRepo = articleRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<int>> GetYearlyArticleCounts() 
        {
            var articles = await _articleRepo.GetAll(x => x.IsDeleted == false);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);     //startDate'in içinde bulunduğu yılın 1. ayının 1. günü

            List<int> datas = new();
            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);   //01.01.2023
                var endedDate = startedDate.AddMonths(1);               //01.02.2023
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                //ilgili tarihler arasındaki makale sayısını bulur ve listeye sayıyı ekler.
                datas.Add(data);
            }

            return datas;
        }

        public async Task<int> GetTotalArticleCount() 
        { 
            var articleCount = await _articleRepo.CountAsync(x => x.IsDeleted == false);
            return articleCount;
        }

        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await _categoryRepo.CountAsync(x => x.IsDeleted == false);
            return categoryCount;
        }
    }
}
