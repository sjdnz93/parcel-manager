using ParcelApi.Models;
using ParcelApi.Models.Bags;

namespace Tests.DataMock;

public static class MockDb
{
  public static List<Shipment> Shipments { get; } = new List<Shipment>
    {
        new Shipment
        {
            ShipmentId = "AA1-AAAAA1",
            Airport = 0,
            DestinationCountry = "LV",
            FlightNumber = "BF9317",
            FlightDate = DateTime.Now.AddDays(10),
            Bags = new List<Bag>
            {
                new ParcelBag
                {
                    Parcels = new List<Parcel>
                    {
                        new Parcel
                        {
                            ParcelId = "uU304269lc",
                            RecipientName = "Jeff",
                            DestinationCountry = "LV",
                            Weight = 123,
                            Price = 123
                        }
                    },
                    BagId = "AYEWT440g7Y2J5Q",
                    BagType = "Parcel",
                    IsFinalised = false,
                    DestinationCountry = "LV",
                    ItemCount = 1,
                    Price = 123,
                    Weight = 123
                },

                new LetterBag
                {
                    BagId = "0YEWT440g7Y2J5Z",
                    BagType = "Letter",
                    IsFinalised = false,
                    DestinationCountry = "LV",
                    ItemCount = 2,
                    Price = 2,
                    Weight = 2,
                    LetterCount = 2
                }
            },
            IsFinalised = false
        },
    };

  public static List<Shipment> GetMockData()
  {
    return Shipments.ToList();
  }

  public static void AddShipment(Shipment shipment)
  {
    Shipments.Add(shipment);
  }

}
