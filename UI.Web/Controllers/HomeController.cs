using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Comment;
using Core.Concretes.DTOs.Notification;
using Core.Concretes.DTOs.Post;
using Core.Concretes.DTOs.PostLike;
using Core.Concretes.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Web.Models;
using UI.Web.Models.Home;

namespace UI.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPostService service;
        private readonly IPostLikeService likeService;
        private readonly ICommentService commentService;
        private readonly INotificationService notificationService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public HomeController(IPostService service, IMapper mapper, UserManager<ApplicationUser> userManager, IPostLikeService likeService, ICommentService commentService, INotificationService notificationService)
        {
            this.service = service;
            _mapper = mapper;
            _userManager = userManager;
            this.likeService = likeService;
            this.commentService = commentService;
            this.notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                Posts = await service.GetAllAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NewPostViewModel model)
        {
            model.MemberId = (await _userManager.GetUserAsync(User))!.Id;
            if (model.AttachedImage != null)
            {
                // Save the image to a directory and set the URL
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.AttachedImage.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.AttachedImage.CopyToAsync(fileStream);
                }

                model.AttachedImageUrl = $"/uploads/{uniqueFileName}";
            }

            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            var post = _mapper.Map<CreatePostDto>(model);
            await service.CreateAsync(post);
            return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> Like(string postId)
        {
            var userId = _userManager.GetUserId(User)!;
            var post = await service.GetByIdAsync(Guid.Parse(postId));
            var likeDto = new CreatePostLikeDto
            {
                PostId = Guid.Parse(postId),
                MemberId = Guid.Parse(userId)
            };
            await likeService.CreateAsync(likeDto);
            var notification = new CreateNotificationDTO
            {
                MemberId = post.MemberId,
                Message = "Your post has been liked.",
                Type = "Like",
                RelatedPostId = Guid.Parse(postId)
            };
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Comment(string postId, string commentContent)
        {
            var post = await service.GetByIdAsync(Guid.Parse(postId));
            var comment = new CreateCommentDto
            {
                PostId = Guid.Parse(postId),
                Content = commentContent,
                MemberId = (await _userManager.GetUserAsync(User))!.Id
            };
            if (ModelState.IsValid)
            {
                await commentService.CreateAsync(comment);
                var notification = new CreateNotificationDTO
                {
                    MemberId = post.MemberId,
                    Message = "Your post has a new comment.",
                    Type = "Comment",
                    RelatedPostId = Guid.Parse(postId)
                };
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
