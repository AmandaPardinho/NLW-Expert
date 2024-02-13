using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        //classe que contém a regra de negócio

        public Auction? Execute()
        {
            var repository = new RocketseatAuctionDbContext();
            var today = DateTime.Now;

            return repository
                .Auctions
                .Include(act => act.Items)
                .FirstOrDefault(act => today >= act.Starts && today <= act.Ends);            
        }
    }
}
