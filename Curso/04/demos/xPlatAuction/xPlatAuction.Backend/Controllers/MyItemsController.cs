using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using xPlatAuction.Backend.Models;
using System.Collections.Generic;
using xPlatAuction.Backend.DataObjects;
using System.Linq;

namespace xPlatAuction.Backend.Controllers
{
    [MobileAppController]
    public class MyItemsController : ApiController
    {
        public IEnumerable<MyAuctionItem> Get()
        {

            MobileServiceContext ctx = new MobileServiceContext();
            var myItems = from ai in ctx.AuctionItems
                          select new MyAuctionItem
                          {
                              Id = ai.Id,
                              Name = ai.Name,
                              Description = ai.Description,
                              CurrentBid = ai.Bids.Count == 0 ? 0 : ai.Bids.Max(b => b.BidAmount),
                              MyHighestBid = 0 //we'll fix this later
                          };

            return myItems;
        }
    }
}
