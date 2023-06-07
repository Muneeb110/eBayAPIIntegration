using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBayAPIIntegration.Contracts
{
    /// <summary>
    /// This class is responsible for holding the responses returned by eBay search API
    /// It is cascaded in nature, hierarchies are being followed.
    /// </summary>
    public class ItemInfo
    {
        public string href { get; set; }
        public int total { get; set; }
        public string next { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<ItemSummary> itemSummaries { get; set; }
    }

    public class AdditionalImage
    {
        public string imageUrl { get; set; }
    }

    public class Category
    {
        public string categoryId { get; set; }
        public string categoryName { get; set; }
    }

    public class Image
    {
        public string imageUrl { get; set; }
    }

    public class ItemLocation
    {
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    public class ItemSummary
    {
        public string itemId { get; set; }
        public string title { get; set; }
        public List<string> leafCategoryIds { get; set; }
        public List<Category> categories { get; set; }
        public Price price { get; set; }
        public string itemHref { get; set; }
        public Seller seller { get; set; }
        public string condition { get; set; }
        public string conditionId { get; set; }
        public List<ShippingOption> shippingOptions { get; set; }
        public List<string> buyingOptions { get; set; }
        public string itemAffiliateWebUrl { get; set; }
        public string itemWebUrl { get; set; }
        public ItemLocation itemLocation { get; set; }
        public bool adultOnly { get; set; }
        public string legacyItemId { get; set; }
        public bool availableCoupons { get; set; }
        public DateTime itemCreationDate { get; set; }
        public bool topRatedBuyingExperience { get; set; }
        public bool priorityListing { get; set; }
        public string listingMarketplaceId { get; set; }
        public string itemGroupHref { get; set; }
        public Image image { get; set; }
        public string itemGroupType { get; set; }
        public List<ThumbnailImage> thumbnailImages { get; set; }
        public List<AdditionalImage> additionalImages { get; set; }
    }

    public class Price
    {
        public string value { get; set; }
        public string currency { get; set; }
    }

    public class Seller
    {
        public int feedbackScore { get; set; }
        public string username { get; set; }
        public string feedbackPercentage { get; set; }
    }

    public class ShippingCost
    {
        public string value { get; set; }
        public string currency { get; set; }
    }

    public class ShippingOption
    {
        public string shippingCostType { get; set; }
        public ShippingCost shippingCost { get; set; }
    }

    public class ThumbnailImage
    {
        public string imageUrl { get; set; }
    }


}
