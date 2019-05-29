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
    public class ChatController : Controller
    {
        AppUserService appUserService;
        ChatService chatService;
        public ChatController()
        {
            appUserService = new AppUserService();
            chatService = new ChatService();

        }
        public ActionResult Inbox()
        {
            ChatVM model = new ChatVM()
            {
                AppUsers=appUserService.GetActive(),
                Chats=chatService.GetActive(),
                user=appUserService.GetByDefault(x=>x.UserName==User.Identity.Name)

            };           

            return View(model);
        }
        [HttpPost]
        public ActionResult Inbox(Chat data)
        {
            AppUser user = appUserService.GetByDefault(x => x.UserName==User.Identity.Name);
            data.AppUserID = user.ID;
            data.CreatedDate = DateTime.Now;
            data.UserName = user.UserName;
            chatService.Add(data);
            return Redirect("/Member/Chat/Inbox");
        }
    }
}