namespace Epc.Core.EpcEnums
{
    //2375 10.2 Filter Values for SGTIN EPC Tags
    public enum SgtinFilter
    {
        AllOther = 0,
        PointOfSaleTradeItem = 1,
        FullCaseForTransport = 2,
        Reserved = 3,
        InnerPackTradeItemGroupingForHandling = 4,
        Reserved2 = 5,
        UnitLoad = 6,
        UnitInsideTradeItemOrComponentInsideAProductNotIntendedForIndividualSale = 7,
    }
}
