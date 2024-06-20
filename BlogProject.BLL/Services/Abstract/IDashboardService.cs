using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Abstract
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyArticleCounts();

        Task<int> GetTotalArticleCount();

        Task<int> GetTotalCategoryCount();
    }
}
