using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBayAPIIntegration.APIParams
{
    /// <summary>
    /// This class is an extensive filter which is supported by eBay
    /// Documentation : https://developer.ebay.com/api-docs/buy/static/ref-buy-browse-filters.html
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Lower bound for bidcount filter
        /// </summary>
        public int? LowerBoundBidCount { get; set; }
        
        /// <summary>
        /// Upper bound for bidcount filter - should be greater than Lower bound
        /// </summary>
        public int? UpperBoundBidCount { get; set; }


        /// <summary>
        /// Only items offering the specified buying formats are returned. Multiple values can be used for this filter and are separated by the pipe symbol - '|'.
        ///
        ///Valid Values:FIXED_PRICE - Items offered for a fixed-price(Buy It Now).These items can also be offered as an auction.Once a bid is placed, FIXED_PRICE is no longer available and the item is now only available as an auction.When this happens, that item will not be return using this filter.
        ///AUCTION - Items offered only as an auction whether they have bids or not.
        ///BEST_OFFER - Items where the buyer can send the seller a price they're willing to pay for the item. The seller can accept, reject, or send a counter offer. For details about Best Offer, see Best Offer.
        ///Note: This filter is not supported in the Marketplace Insights API.
        ///CLASSIFIED_AD - Items that have been listed on eBay but state that the final sales transaction is to be completed outside of the eBay environment.
        /// </summary>
        public BuyingOptions BuyingOptions { get; set; }

        /// <summary>
        /// Only items associated with a charity are returned.
        /// </summary>
        public bool CharityOnly { get; set; }

        /// <summary>
        /// Only items with the specified condition ID are returned. Multiple values can be used for this filter and are separated by the pipe symbol - '|'.
        /// </summary>
        public List<int> ConditionIds { get; set; }

        public Condition Condition { get; set; }

        /// <summary>
        /// Last Sold date filter - starting point
        /// </summary>
        public DateTime? LastSoldDateFrom { get; set; }

        /// <summary>
        /// Last Sold date filter - ending point
        /// </summary>
        public DateTime? LastSoldDateTo { get; set; }

        /// <summary>
        /// Only items with free shipping are returned.
        /// </summary>
        public bool FreeShipping { get; set; }

        /// <summary>
        /// Only items that offer payment by credit card are returned.
        /// </summary>
        public bool PaymentByCreditCardOnly { get; set; }

        /// <summary>
        /// Only items located in the specified country are returned.
        /// Valid Values (case sensitive): Two-character ISO 3166 Country Code
        /// </summary>
        public string ItemLocationCountry { get; set; }

        /// <summary>
        /// This filter, along with the three other pickup filters, sets the local pickup radius.Only items that are available through local pickup and within the pickup radius set by the user are retrieved.
        /// Requirement: The method must include all the pickup filters(pickupCountry, pickupPostalCode, pickupRadius, and pickupRadiusUnit) and the deliveryOptions filter.
        /// Valid Values (case sensitive): Two-character ISO 3166 Country Code
        /// </summary>
        public string PickupCountry { get; set; }

        /// <summary>
        /// This filter, along with the three other pickup filters, sets the local pickup radius. Only items that are available through local pickup and within the pickup radius set by the user are retrieved. The pickupPostalCode value is generally the postal code of the buyer's address.
        /// Requirement: The method must include all the pickup filters(pickupCountry, pickupPostalCode, pickupRadius, and pickupRadiusUnit) and the deliveryOptions filter.
        /// Valid Values: A postal or zip code.
        /// </summary>
        public string PickupPostalCode { get; set; }


        /// <summary>
        ///  This filter, along with the three other pickup filters, sets the local pickup radius.Only items that are available through local pickup and within the pickup radius set by the user are retrieved.
        ///  Requirement: The method must include all the pickup filters(pickupCountry, pickupPostalCode, pickupRadius, and pickupRadiusUnit) and the deliveryOptions filter.
        ///  The pickupRadius value defines the distance that the buyer iswilling to travel (in miles or km) from the postal code defined in the pickupPostalCode filter to pick up the item.
        /// </summary>
        public int PickupRadius { get; set; }

        /// <summary>
        /// This filter, along with the three other pickup filters, sets the local pickup radius. Only items that are available through local pickup and within the pickup radius set by the user are retrieved. The pickupRadiusUnit defines the distance measurement unit used for the pickup radius.
        /// Requirement: The method must include all the pickup filters(pickupCountry, pickupPostalCode, pickupRadius, and pickupRadiusUnit) and the deliveryOptions filter.
        /// Valid values: mi,km
        /// </summary>
        public string PickupRadiusUnit { get; set; }

        /// <summary>
        /// Only local pickup items are returned.
        /// Requirement:This filter must be used with the pickupCountry, pickupPostalCode, pickupRadius, and pickupRadiusUnit filters.
        /// Valid Values:SELLER_ARRANGED_LOCAL_PICKUP
        /// </summary>
        public bool EnableDeliveryOptions { get; set; }

        /// <summary>
        /// Any items from the specified sellers are not returned in the response. Multiple values can be used for this filter and are separated by the pipe symbol - '|'.
        /// Valid Values: The sellers' eBay user ID.
        /// </summary>
        public List<string> ExcludeSellers { get; set; }

        public List<int> ExcludeCategoryIds { get; set; }

        /// <summary>
        /// Valid Values (case sensitive): Two-character ISO 3166 Country Code.
        /// </summary>
        public string DeliveryCountry { get; set; }

        /// <summary>
        /// Only items that can be shipped to the specified postal/zip code are returned.
        /// Requirement: This filter must be used with the deliveryCountry filter.
        /// </summary>
        public string DeliveryPostalCode{ get; set; }


        /// <summary>
        /// Lower range for ItemEndDate
        /// </summary>
        public DateTime? ItemEndDateFrom { get; set; }

        /// <summary>
        /// Upper range for ItemEndDate
        /// </summary>
        public DateTime? ItemEndDateTo { get; set; }


        /// <summary>
        /// Lower range for ItemStartDate
        /// </summary>
        public DateTime? ItemStartDateFrom { get; set; }

        /// <summary>
        /// Upper range for ItemStartDate
        /// </summary>
        public DateTime? ItemStartDateTo { get; set; }

        /// <summary>
        /// Lower range for price
        /// Requirement: This filter must be used with the priceCurrency filter.
        /// </summary>
        public int LowerBoundPrice { get; set; }
        /// <summary>
        /// Upper range for price
        /// Requirement: This filter must be used with the priceCurrency filter.
        /// </summary>
        public int UpperBoundPrice { get; set; }

        /// <summary>
        /// Specifies the currency tied to the price.
        /// Valid Values(case sensitive): The three-digit Currency codes(ISO 4217 standard).
        /// Restriction: This filter is only needed if the price(range) filter is used.
        /// </summary>
        public string PriceCurrency { get; set; }

        /// <summary>
        /// Only items that are eligible for eBay qualified programs, such as EBAY_PLUS, AUTHENTICITY_GUARANTEE, and AUTHENTICITY_VERIFICATION, are returned.
        /// Note: In order for the search method to return items for this container, the filters deliveryCountry and deliveryPostalCode must be present.
        /// Note: Add | in between multiple elements for example; EBAY_PLUS|AUTHENTICITY_VERIFICATION.
        /// </summary>
        public string QualifiedPrograms { get; set; }

        public bool ReturnsAccepted { get; set; }

        public bool SearchInDescription { get; set; }

        /// <summary>
        /// Restriction: You can filter by either BUSINESS or INDIVIDUAL. But you cannot filter by both.
        /// Valid Values(case sensitive):BUSINESS,INDIVIDUAL
        /// </summary>
        public string SellerAccountTypes { get; set; }

        public List<string> Sellers{ get; set; }

        public int GuaranteedDeliveryInDays { get; set; }

        public override string ToString()
        {
            StringBuilder filter = new StringBuilder();
            string flags = string.Empty;
            #region bidCount
            if (LowerBoundBidCount.HasValue && UpperBoundBidCount.HasValue)
                filter.Append(string.Format("bidCount:[{0}..{1}],", LowerBoundBidCount.Value, UpperBoundBidCount.Value));
            else if (UpperBoundBidCount.HasValue && !LowerBoundBidCount.HasValue)
                filter.Append(string.Format("bidCount:[..{0}],", UpperBoundBidCount.Value));
            else if (LowerBoundBidCount.HasValue && !UpperBoundBidCount.HasValue)
                filter.Append(string.Format("bidCount:[{0}],", LowerBoundBidCount.Value));
            #endregion

            #region Buying Options
            if (BuyingOptions != null)
            {
                
                if (BuyingOptions.FixedPrice)
                    flags += "FIXED_PRICE|";
                if (BuyingOptions.Auction)
                    flags += "AUCTION|";
                if (BuyingOptions.BestOffer)
                    flags += "BEST_OFFER|";
                if (BuyingOptions.ClassifiedAd)
                    flags += "CLASSIFIED_AD|";

                flags = flags.TrimEnd('|');
                filter.AppendFormat("buyingOptions:{{{0}}},",flags);
            }
            flags = string.Empty;
            #endregion

            if (CharityOnly)
                filter.Append("charityOnly:true,");

            #region ConditionIds
            if (ConditionIds != null && ConditionIds.Count > 0)
            {
                foreach (var cid in ConditionIds)
                {
                    flags += cid + "|";
                }
                flags = flags.TrimEnd('|');
                filter.AppendFormat("conditionIds:{{{0}}},", flags);
                flags = string.Empty;
            }
            #endregion

            #region Condition
            if (Condition != null)
            {
                if (Condition.New)
                    flags += "NEW|";
                if (Condition.Used)
                    flags += "USED|";
                if (Condition.Unspecified)
                    flags += "UNSPECIFIED|";
                flags = flags.TrimEnd('|');
                filter.AppendFormat("conditions:{{{0}}},", flags);
                flags = string.Empty;
            }
            #endregion

            if (ExcludeSellers != null && ExcludeSellers.Count > 0)
            {
                foreach (var seller in ExcludeSellers)
                {
                    flags += seller + "|";
                }
                flags = flags.TrimEnd('|');
                filter.AppendFormat("excludeSellers:{{{0}}},", flags);
                flags = string.Empty;
            }

            if (ExcludeCategoryIds != null && ExcludeCategoryIds.Count > 0)
            {
                foreach (var category in ExcludeCategoryIds)
                {
                    flags += category + "|";
                }
                flags = flags.TrimEnd('|');
                filter.AppendFormat("excludeCategoryIds:{{{0}}},", flags);
                flags = string.Empty;
            }

            if (!string.IsNullOrEmpty(ItemLocationCountry))
                filter.AppendFormat("itemLocationCountry:{0},", ItemLocationCountry);

            //2018-08-30T00:00:00Z
            if (LastSoldDateFrom.HasValue && LastSoldDateTo.HasValue)
                filter.AppendFormat("lastSoldDate:[{0}..{1}],", LastSoldDateFrom.Value.ToString("yyyy-MM-ddT00:00:00Z"), 
                                                               LastSoldDateTo.Value.ToString("yyyy-MM-ddT00:00:00Z"));

            if (FreeShipping)
                filter.Append("maxDeliveryCost:0,");

            if (PaymentByCreditCardOnly)
                filter.Append("paymentMethods:{CREDIT_CARD},");

            // API Restrictions.These options are to be used together - else will not work
            if (!string.IsNullOrEmpty(PickupCountry) &&
                !string.IsNullOrEmpty(PickupPostalCode) &&
                PickupRadius > 0 &&
                !string.IsNullOrEmpty(PickupRadiusUnit) &&
                EnableDeliveryOptions)
            {
                filter.AppendFormat("pickupCountry:{0},pickupPostalCode:{1},pickupRadius:{2},pickupRadiusUnit:{3},"
                                    , PickupCountry, PickupPostalCode, PickupRadius, PickupRadiusUnit);
                filter.Append("deliveryOptions:{SELLER_ARRANGED_LOCAL_PICKUP},");
            }
            
            if(!string.IsNullOrEmpty(DeliveryPostalCode) && !string.IsNullOrEmpty(DeliveryCountry))
            {
                if (GuaranteedDeliveryInDays == 0 || GuaranteedDeliveryInDays > 4)
                    filter.AppendFormat("deliveryPostalCode:{0},deliveryCountry:{1},", DeliveryPostalCode, DeliveryCountry);
                else
                    filter.AppendFormat("guaranteedDeliveryInDays:{0},deliveryPostalCode:{1},deliveryCountry:{2},", GuaranteedDeliveryInDays, DeliveryPostalCode, DeliveryCountry);
            }
            else if(!string.IsNullOrEmpty(DeliveryCountry))
            {
                filter.AppendFormat("deliveryCountry:{0},", DeliveryCountry);
            }

            if (ItemEndDateFrom.HasValue && ItemEndDateTo.HasValue)
                filter.Append(string.Format("itemEndDate:[{0}..{1}],", ItemEndDateFrom.Value.ToString("yyyy-MM-ddT00:00:00Z"), ItemEndDateTo.Value.ToString("yyyy-MM-ddT00:00:00Z")));
            else if (ItemEndDateTo.HasValue && !ItemEndDateFrom.HasValue)
                filter.Append(string.Format("itemEndDate:[..{0}],", ItemEndDateTo.Value.ToString("yyyy-MM-ddT00:00:00Z")));
            else if (ItemEndDateFrom.HasValue && !ItemEndDateTo.HasValue)
                filter.Append(string.Format("itemEndDate:[0}],", ItemEndDateTo.Value.ToString("yyyy-MM-ddT00:00:00Z")));

            if (ItemStartDateFrom.HasValue && ItemStartDateTo.HasValue)
                filter.Append(string.Format("itemEndDate:[{0}..{1}],", ItemStartDateFrom.Value.ToString("yyyy-MM-ddT00:00:00Z"), ItemStartDateTo.Value.ToString("yyyy-MM-ddT00:00:00Z")));
            else if (ItemStartDateTo.HasValue && !ItemStartDateFrom.HasValue)
                filter.Append(string.Format("itemEndDate:[..{0}],", ItemStartDateTo.Value.ToString("yyyy-MM-ddT00:00:00Z")));
            else if (ItemStartDateFrom.HasValue && !ItemStartDateTo.HasValue)
                filter.Append(string.Format("itemEndDate:[{0}],", ItemStartDateFrom.Value.ToString("yyyy-MM-ddT00:00:00Z")));

            if (!string.IsNullOrEmpty(PriceCurrency))
            {
                if (LowerBoundPrice > 0 && UpperBoundPrice > 0)
                    filter.Append(string.Format("price:[{0}..{1}],", LowerBoundPrice, UpperBoundPrice));
                else if (UpperBoundPrice > 0 && LowerBoundBidCount <= 0)
                    filter.Append(string.Format("price:[..{0}],", UpperBoundPrice));
                else if (LowerBoundPrice > 0 && UpperBoundPrice <= 0)
                    filter.Append(string.Format("price:[{0}],", LowerBoundPrice));

                filter.AppendFormat("priceCurrency:{0},",PriceCurrency);
            }

            if(!string.IsNullOrEmpty(QualifiedPrograms))
                filter.AppendFormat("qualifiedPrograms:{{{0}}},",QualifiedPrograms);

            if(ReturnsAccepted)
                filter.Append("returnsAccepted:true,");

            if(SearchInDescription)
                filter.Append("searchInDescription:true,");

            if (!string.IsNullOrEmpty(SellerAccountTypes))
                filter.AppendFormat("sellerAccountTypes:{{{0}}},", SellerAccountTypes);

            if (Sellers != null && Sellers.Count > 0)
            {
                foreach (var seller in Sellers)
                {
                    flags += seller + "|";
                }
                flags = flags.TrimEnd('|');
                filter.AppendFormat("sellers:{{{0}}},", flags);
                flags = string.Empty;
            }
            flags = filter.ToString().TrimEnd(',');

            return flags;
        }
    }

    public class BuyingOptions
    {
        public bool FixedPrice { get; set; }
        public bool Auction { get; set; }
        public bool BestOffer { get; set; }
        public bool ClassifiedAd { get; set; }
    }

    /// <summary>
    /// Only items in the specified conditions are returned. Item condition values can vary by category. Multiple values can be used for this filter and are separated by the pipe symbol - '|'.
    /// Unlike the conditionID filter, the conditions filter will not return items of a specific condition such as Good, Very Good, or Seller Refurbished.It will only return items that are categorized by the broader conditions of NEW and USED
    /// </summary>
    public class Condition
    {
        public bool Used { get; set; }
        public bool New { get; set; }
        public bool Unspecified { get; set; }
    }
}
