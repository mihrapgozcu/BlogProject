using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Entities;
using BlogProject.DAL.UnitOfWorks;
using BlogProject.DAL.ViewModels.Authors;
using BlogProject.Web.Consts;
using BlogProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Policy;

namespace BlogProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IArticleVisitorRepository _articleVisitorRepo;
        private readonly IArticleRepository _articleRepo;
        private readonly IVisitorRepository _visitorRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

       public HomeController(ILogger<HomeController> logger, IArticleService articleService, IHttpContextAccessor httpContextAccessor, IArticleVisitorRepository articleVisitorRepo, IArticleRepository articleRepo, IVisitorRepository visitorRepo, IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _articleService = articleService;
            _httpContextAccessor = httpContextAccessor;
            _articleVisitorRepo = articleVisitorRepo;
            _articleRepo = articleRepo;
            _visitorRepo = visitorRepo;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }


        //Açılış sayfası için.
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Author}")]
        public async Task<IActionResult> Index(int categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.GetAllByPaging(categoryId, currentPage, pageSize, isAscending);

            return View(articles);
        }


        //Arama çubuğu için.
        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Author}")]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.Search(keyword, currentPage, pageSize, isAscending);

            return View(articles);
        }


        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Author}")]
        public async Task<IActionResult> Detail(int id) 
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            //GetAll'un include parametresi sayesinde visitor ve article birleştirildi. (Çoka çok tablo)
            var articleVisitors = await _articleVisitorRepo.GetAll(null, x => x.Visitor, y => y.Article);
            var article = await _articleRepo.GetAsync(x => x.Id == id);
            var visitor = await _visitorRepo.GetAsync(x => x.IpAddress == ipAddress);
            
            var addArticleVisitors = new ArticleVisitor() 
            { 
                VisitorId = visitor.Id,
                ArticleId = article.Id
            };

            var result = await _articleService.GetArticleWithCategoryNonDeleted(id);

            //Eğer articlevisitor tablosu içinde yeni yaratılan article ve visitor varsa tabloya ekleme. Yoksa makalenin view count'ını +1 yaparak tabloya ekle.
            if (articleVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId))
            {
                return View(result);
            }
            else
            {
                await _articleVisitorRepo.Create(addArticleVisitors);
                
                article.ViewCount += 1;
                await _articleRepo.Update(article);
                await _unitOfWork.SaveAsync();
            }
            
            return View(result);
        }


        public IActionResult About()
        {
            return View();
        }


        [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Author}")]
        public async Task<IActionResult> AuthorDetail(int userId)
        {
            var author = await _userService.GetAppUserById(userId);

            var articles = await _articleRepo.GetAll(x => x.UserId == userId);

            var map = _mapper.Map<AuthorDetailVM>(author);
            map.Articles = articles;

            return View(map);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}