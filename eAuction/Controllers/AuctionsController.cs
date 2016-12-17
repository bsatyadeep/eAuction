using eAuction.Data;
using eAuction.Models;
using System.Linq;
using System.Web.Mvc;

namespace eAuction.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Autions
        [AllowAnonymous]
        public ActionResult Index()
        {
            var auctions = (new AuctionsDataContext()).Auctions.ToArray();
            return View(auctions);
        } 

        public ActionResult Auction(long id)
        {
            var db = new AuctionsDataContext();

            var auction = db.Auctions.Find(id);
            //ViewData["Auction"] = auction;
            return View(auction);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categoryList = new SelectList(new[] { "Automative", "Electronics", "Games", "Home" });
            ViewData["CategoryList"] = categoryList;
            return View(new Auction());
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "CurrentPrice")]Auction auction)
        {

            if (ModelState.IsValid)
            {
                var db = new AuctionsDataContext();
                db.Auctions.Add(auction);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return Create();
        }

        [HttpPost]
        public ActionResult Bid(Bid bid)
        {
            var db = new AuctionsDataContext();
            var auction = db.Auctions.Find(bid.AuctionId);
            if (auction == null)
            {
                ModelState.AddModelError("AuctionId", "Auction Not Found");
            }
            else if (auction.CurrentPrice >= bid.Amount)
            {
                ModelState.AddModelError("Amount", "Bid Amount must exceed current Bid");
            }
            else
            {
                bid.Username = User.Identity.Name;
                auction.Bids.Add(bid);
                auction.CurrentPrice = bid.Amount;
                db.SaveChanges();
            }
            if (!Request.IsAjaxRequest())
            {
                return RedirectToAction("Auction", new { id = bid.AuctionId });
            }
            //var httpStatus = ModelState.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            //return new HttpStatusCodeResult(httpStatus);

            return Json(new
            {
                CurrentPrice = bid.Amount.ToString("C"),
                BidCount = auction.BidCount
            });
        }
    }
}