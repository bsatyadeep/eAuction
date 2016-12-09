using System;

namespace eAuction.Models
{
    public class Auction
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgageUrl { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public decimal StartPrice { get; set; }
        public decimal? CurrentPrice { get; set; }
    }
}