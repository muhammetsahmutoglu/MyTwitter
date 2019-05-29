using MyTwitter.Model.Option;
using MyTwitter.Service.Option;
using MyTwitter.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTwitter.UI.Areas.Member.Controllers
{
    public class TimeLineController : Controller
    {
        CommentService commentService;
        AppUserService appUserService;
        TweetService tweetService;
        public TimeLineController()
        {
            appUserService = new AppUserService();
            commentService = new CommentService();
            tweetService = new TweetService();
        }
        public ActionResult List()
        {
            TweetVM model = new TweetVM()
            {
                AppUsers = appUserService.GetActive(),
                Tweets = tweetService.GetActive().OrderByDescending(x => x.CreatedDate).ToList(),
                Comments = commentService.GetActive(),
                user = appUserService.GetByDefault(x => x.UserName == User.Identity.Name),

            };
            return View(model);
        }        

        
    }
}