using CinemaSearcher.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CinemaSearcher.Business.Searching
{
    public class TicketSearchBuilder : ISearchBuilder<Ticket>
    {
        public Expression<Func<Ticket, bool>> Filter { get; set; }
        public TicketSearchModel SearchModel { get; set; }

        public TicketSearchBuilder(TicketSearchModel searchModel)
        {
            SearchModel = searchModel;
            Filter = PredicateBuilder.True<Ticket>();
        }
        public Expression<Func<Ticket, bool>> Build()
        {
            AddToPriceFilter(SearchModel.PriceFilter.To)
                .AddFromPriceFilter(SearchModel.PriceFilter.From)
                .AddDateFilter(SearchModel.DateFilter);
            return Filter;
        }

        private TicketSearchBuilder AddToPriceFilter(decimal priceTo)
        {
            Filter = PredicateBuilder.And(Filter, ticket => (priceTo > 0) ? ticket.Price < priceTo : true);
            return this;
        }

        private TicketSearchBuilder AddFromPriceFilter(decimal priceFrom)
        {
            Filter = PredicateBuilder.And(Filter, ticket => (priceFrom > 0) ? ticket.Price > priceFrom : true);
            return this;
        }

        private TicketSearchBuilder AddDateFilter(DateFilter dateFilter)
        {
            DateTime date;
            switch (dateFilter)
            {
                case DateFilter.LastWeek:
                    date = DateTime.Today.AddDays(-7);
                    break;
                case DateFilter.LastMonth:
                    date = DateTime.Today.AddMonths(-1);
                    break;
                case DateFilter.LastYear:
                    date = DateTime.Today.AddYears(-1);
                    break;
                case DateFilter.LastTwoYears:
                    date = DateTime.Today.AddYears(-2);
                    break;
                case DateFilter.LastThreeYears:
                    date = DateTime.Today.AddYears(-3);
                    break;
                default:
                    date = DateTime.Today;
                    break;
            }
            Filter = PredicateBuilder.And(Filter, ticket => (dateFilter > 0) ? ticket.Date > date : true);
            return this;
        }

    }
}
