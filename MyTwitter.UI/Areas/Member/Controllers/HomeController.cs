using MyTwitter.Model.Option;
using MyTwitter.Service.Option;
using MyTwitter.UI.Areas.Member.Models.DTO;
using MyTwitter.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTwitter.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        CommentService commentService;
        AppUserService appUserService;
        TweetService tweetService;
        public HomeController()
        {
            appUserService = new AppUserService();
            commentService = new CommentService();
            tweetService = new TweetService();
        }
        // GET: Member/Home
        public ActionResult Index()
        {
            TweetVM model = new TweetVM()
            {
                AppUsers = appUserService.GetActive(),
                Tweets=tweetService.GetActive().OrderByDescending(x=>x.CreatedDate).ToList(),
                Comments=commentService.GetActive(),
                userName=appUserService.GetByDefault(x=>x.UserName==User.Identity.Name).UserName,
                UserID= appUserService.GetByDefault(x => x.UserName == User.Identity.Name).ID,

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Tweet data)
        {
            AppUser user = appUserService.GetByDefault(x => x.UserName == User.Identity.Name);
            data.AppUserID = user.ID;
            data.TweetUserName = user.UserName;
            if (data.Content==null)
            {
                return Redirect("/Member/Home/Index");
            }
            tweetService.Add(data);
            return Redirect("/Member/Home/Index");

        } 
        public ActionResult TweetDelete(Guid id)
        {
            Tweet tweet = tweetService.GetByID(id);
            tweet.Status = Core.Enum.Status.Deleted;
            tweet.ModifiedDate = DateTime.Now;
            tweetService.Update(tweet);
            return Redirect("/Member/Home/Index");
        }

        public ActionResult CommentAdd(Guid id)
        {
            Tweet tweet = tweetService.GetByID(id);
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.TweetID = tweet.ID;
            commentDTO.TweetUserID = tweet.AppUserID;
            commentDTO.TweetContent = tweet.Content;
            AppUser user = appUserService.GetByDefault(x => x.UserName == User.Identity.Name);
            commentDTO.TweetUserName = tweet.TweetUserName;
            commentDTO.username = user.UserName;
            return View(commentDTO);

        }

        [HttpPost]
        public ActionResult CommentAdd(CommentDTO comment)
        {
            Comment data = new Comment();
            AppUser user = appUserService.GetByDefault(x => x.UserName == User.Identity.Name);            
            data.AppUserID = user.ID;
            data.CommentUserName = user.UserName;
            data.TweetID = comment.TweetID;
            data.Content = comment.CommentContent;
            if (data.Content == null)
            {
               return Redirect("/Member/Home/Index");
            }
            commentService.Add(data);
            return Redirect("/Member/Home/Index");            
            

        }
        public ActionResult CommentDelete(Guid id)
        {
            Comment comment = new Comment();
            comment = commentService.GetByID(id);
            comment.Status = Core.Enum.Status.Deleted;
            commentService.Update(comment);
            return Redirect("/Member/Home/Index");
        }


    }
}