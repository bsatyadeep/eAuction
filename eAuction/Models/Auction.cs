using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace eAuction.Models
{
    public class Auction
    {
        [Required]
        public long Id { get; set; }
        [Required, Display(Name = "Title"), StringLength(maximumLength: 200, MinimumLength = 5), DataType(DataType.Text)]
        public string Title { get; set; }
        [Required, Display(Name = "Auction Description"), StringLength(maximumLength: 200, MinimumLength = 5), DataType(DataType.Text)]
        public string Description { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image Url")]
        public string ImgageUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Start Price")]
        public decimal StartPrice { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Current Bid Price")]
        public decimal? CurrentPrice { get; set; }

        [Required, DataType(DataType.Text)]
        public string Category { get; set; }
        public virtual Collection<Bid> Bids { get; private set; }

        public int BidCount
        {
            get { return Bids.Count; }
        }
        public Auction()
        {
            Bids = new Collection<Bid>();
        }
    }
}