using eAuction.Models;
using System;
using System.Web.Mvc;

namespace eAuction.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Autions
        public ActionResult Index()
        {
            var auctions = new[] {
                new Auction
                {
                    Title = "Example Auction #1",
                    Description = "This is a demo Auction #1",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = null
                },
                new Auction
                {
                    Title = "Example Auction #2",
                    Description = "This is a demo Auction #2",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(7),
                    StartPrice = 1.00m,
                    CurrentPrice = null

                }
            };
            return View(auctions);
        }

        public ActionResult Auction()
        {
            var auction = new Auction
            {
                Title = "Example Auction #1",
                Description = "This is a demo Auction #1",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7),
                StartPrice = 1.00m,
                CurrentPrice = null
            };
            //ViewData["Auction"] = auction;
            return View(auction);
        }
    }
}