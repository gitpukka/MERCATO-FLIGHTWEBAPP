using System;
using System.Linq;
using TuiFlightModel.Models;

namespace TuiFlightDataContext
{
    public static class DbInitializer
    {
        public static void Initialize(TuiFlightDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Airlines.Any())
            {
                return;   // DB has been seeded
            }

            var countries = new Country[]
            {
                new Country { CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Code = "FRA", Name = "France" },
                new Country { CountryId = Guid.Parse("3ae77911-11d7-4dc3-affb-318aeca3f3f1"), Code = "BEL", Name = "Belgique" },
            };
            foreach (var e in countries)
            {
                context.Countries.Add(e);
            }
            context.SaveChanges();

            var cities = new City[]
            {
                new City { CityId = Guid.Parse("ca7de36a-72c2-44c9-b61a-c64198ea331a"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Avignon" },
                new City { CityId = Guid.Parse("d85148e1-aaac-48ef-9e49-c20b1b76c132"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Montpellier" },
                new City { CityId = Guid.Parse("9d0ee6cc-19d2-44b6-8e78-6fc1f28a89c1"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Bastia" },
                new City { CityId = Guid.Parse("f4b75613-796e-48eb-8fc0-224a96937df1"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Lille" },
                new City { CityId = Guid.Parse("e376b0f6-1cac-496e-96f8-842c774e2adc"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Marseille" },
                new City { CityId = Guid.Parse("37f8ad8c-585d-4a18-ac70-0f9b7f2a3b3d"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Paris" },
                new City { CityId = Guid.Parse("611ef869-f5a0-402b-b206-0f9bf0124565"), CountryId = Guid.Parse("2c51846c-6e30-44e7-bc4c-bbcce1142a7b"), Name = "Châlons-en-Champagne" },
                new City { CityId = Guid.Parse("002a42bc-54aa-41bc-b223-af084f007264"), CountryId = Guid.Parse("3ae77911-11d7-4dc3-affb-318aeca3f3f1"), Name = "Anvers" },
                new City { CityId = Guid.Parse("3cfdcffa-de76-4ae1-a272-fabfeca9c025"), CountryId = Guid.Parse("3ae77911-11d7-4dc3-affb-318aeca3f3f1"), Name = "Liège" },
                new City { CityId = Guid.Parse("e7846d46-05e4-46ce-aef2-acd684b1b604"), CountryId = Guid.Parse("3ae77911-11d7-4dc3-affb-318aeca3f3f1"), Name = "Ostende" },
                new City { CityId = Guid.Parse("22cc2f0c-705c-4ca0-b29a-d16db8f5aec3"), CountryId = Guid.Parse("3ae77911-11d7-4dc3-affb-318aeca3f3f1"), Name = "Bruxelles" },
            };
            foreach (var e in cities)
            {
                context.Cities.Add(e);
            }
            context.SaveChanges();

            var airlines = new Airline[]
            {
                new Airline { AirlineId = Guid.Parse("0370636f-77f0-4351-9590-47cb5dd399d4"), Name = "Adria Airways (JP)" },
                new Airline { AirlineId = Guid.Parse("ec4497b8-bc10-422b-bbe5-314dcfd576e0"), Name = "Aegean Airlines (A3)" },
                new Airline { AirlineId = Guid.Parse("0d6c9207-5ac1-4b72-b0b2-bc407f96b37d"), Name = "Aer Lingus (EI)" },
                new Airline { AirlineId = Guid.Parse("708ca3f3-e702-43e9-a729-14e4a28c35cf"), Name = "Aeroflot (SU)" },
                new Airline { AirlineId = Guid.Parse("dc0ef059-49f6-497e-954e-b50918fbf033"), Name = "Aeromexico (AM)" },
                new Airline { AirlineId = Guid.Parse("d8d5389e-5365-4d2f-addd-2d6310e76b4c"), Name = "Aigle Azur (ZI)" },
                new Airline { AirlineId = Guid.Parse("e88a683e-b328-4191-b1f1-c96925045ff9"), Name = "Air Algerie (AH)" },
                new Airline { AirlineId = Guid.Parse("90517e3f-9157-4fc3-bef6-de9414d653a1"), Name = "Air Astana (KC)" },
                new Airline { AirlineId = Guid.Parse("60dbc0ee-533b-4203-87e4-e5ee27499294"), Name = "Air Austral (UU)" },
                new Airline { AirlineId = Guid.Parse("0a5cb398-e644-4bba-92bd-a9769bb2ad5a"), Name = "Air Canada (AC)" },
                new Airline { AirlineId = Guid.Parse("57c600ab-7f06-482f-8937-5342363e1128"), Name = "Air China (CA)" },
                new Airline { AirlineId = Guid.Parse("0be6058c-456b-40d1-88f1-fafc38dcec62"), Name = "Air Corsica (XK)" },
                new Airline { AirlineId = Guid.Parse("f5b87b06-dfdf-45ee-bcea-6b6a80c3b856"), Name = "Air Europa (UX)" },
                new Airline { AirlineId = Guid.Parse("9bac5f44-fbdc-469d-ae70-5772aa5798cb"), Name = "Air France (AF)" },
                new Airline { AirlineId = Guid.Parse("ea1e614f-6418-4b57-93b9-ffe2c360dc1e"), Name = "Air India (AI) " },
                new Airline { AirlineId = Guid.Parse("5baadd0c-147b-49d4-8915-f2aee3913c1b"), Name = "Ryanair (FR)" },
                new Airline { AirlineId = Guid.Parse("e8beb337-8f58-4270-9eba-3b30bbd42bad"), Name = "Pegasus Airlines (PC)" },
                new Airline { AirlineId = Guid.Parse("bcb1cad5-3f5e-4bf1-9c84-bc1c64cdd886"), Name = "TUI fly Belgium (TB)" },
                new Airline { AirlineId = Guid.Parse("0fc36598-d9d9-4012-8cc0-407bf535336c"), Name = "Wizz Air (W6)" },
            };
            foreach (var s in airlines)
            {
                context.Airlines.Add(s);
            }
            context.SaveChanges();

            var airports = new Airport[]
            {
                new Airport { AirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), Iata = "AVN", Latitude = 43.9067, Longitude = 4.90194, CountryCode = "FRA", CityId = Guid.Parse("ca7de36a-72c2-44c9-b61a-c64198ea331a"), Name = "Avignon-Caum" },
                new Airport { AirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), Iata = "MPL", Latitude = 43.5833, Longitude = 3.96139, CountryCode = "FRA", CityId = Guid.Parse("d85148e1-aaac-48ef-9e49-c20b1b76c132"), Name = "Montpellier-Méditerranée" },
                new Airport { AirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), Iata = "BIA", Latitude = 0042.55, Longitude = 9.48472, CountryCode = "FRA", CityId = Guid.Parse("9d0ee6cc-19d2-44b6-8e78-6fc1f28a89c1"), Name = "Bastia Airport" },
                new Airport { AirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), Iata = "LIL", Latitude = 50.5633, Longitude = 3.08694, CountryCode = "FRA", CityId = Guid.Parse("f4b75613-796e-48eb-8fc0-224a96937df1"), Name = "Lille Lesquin Airport" },
                new Airport { AirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), Iata = "MRS", Latitude = 43.4367, Longitude = 005.215, CountryCode = "FRA", CityId = Guid.Parse("e376b0f6-1cac-496e-96f8-842c774e2adc"), Name = "Marseille" },
                new Airport { AirportId = Guid.Parse("955e1745-7fec-4e29-97f6-20e6acdd6b4a"), Iata = "BVA", Latitude = 49.4544, Longitude = 2.11278, CountryCode = "FRA", CityId = Guid.Parse("37f8ad8c-585d-4a18-ac70-0f9b7f2a3b3d"), Name = "Paris Beauvais" },
                new Airport { AirportId = Guid.Parse("27e2620e-7e2f-440b-8535-9a82b4c68e09"), Iata = "XPG", Latitude = 48.8809, Longitude = 2.35531, CountryCode = "FRA", CityId = Guid.Parse("611ef869-f5a0-402b-b206-0f9bf0124565"), Name = "Châlons-en-Champagne" },
                new Airport { AirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), Iata = "CDG", Latitude = 49.0097, Longitude = 2.54778, CountryCode = "FRA", CityId = Guid.Parse("37f8ad8c-585d-4a18-ac70-0f9b7f2a3b3d"), Name = "Paris Charles-de-Gaulle" },
                new Airport { AirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), Iata = "ORY", Latitude = 48.7233, Longitude = 2.37944, CountryCode = "FRA", CityId = Guid.Parse("37f8ad8c-585d-4a18-ac70-0f9b7f2a3b3d"), Name = "Paris Orly" },
                new Airport { AirportId = Guid.Parse("a701494d-50bc-476b-9fe7-59afbcd22b60"), Iata = "ANR", Latitude = 51.1894, Longitude = 4.46028, CountryCode = "BEL", CityId = Guid.Parse("002a42bc-54aa-41bc-b223-af084f007264"), Name = "Anvers" },
                new Airport { AirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), Iata = "BRU", Latitude = 50.9014, Longitude = 4.48444, CountryCode = "BEL", CityId = Guid.Parse("22cc2f0c-705c-4ca0-b29a-d16db8f5aec3"), Name = "Bruxelles" },
                new Airport { AirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), Iata = "CRL", Latitude = 50.4592, Longitude = 4.45389, CountryCode = "BEL", CityId = Guid.Parse("22cc2f0c-705c-4ca0-b29a-d16db8f5aec3"), Name = "Bruxelles S. Charleroi" },
                new Airport { AirportId = Guid.Parse("1d9324eb-8593-458e-95e4-8f90bdbc9889"), Iata = "LGG", Latitude = 50.6375, Longitude = 5.44333, CountryCode = "BEL", CityId = Guid.Parse("3cfdcffa-de76-4ae1-a272-fabfeca9c025"), Name = "Liège" },
                new Airport { AirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), Iata = "OST", Latitude = 51.2167, Longitude = 2.91667, CountryCode = "BEL", CityId = Guid.Parse("e7846d46-05e4-46ce-aef2-acd684b1b604"), Name = "Ostende" },
            };
            foreach (var c in airports)
            {
                context.Airports.Add(c);
            }
            context.SaveChanges();

            var flights = new Flight[]
            {
                new Flight { FlightId = Guid.Parse("f7ad434f-d413-49bc-b1f0-c70b9bb8736f"), AirlineId = Guid.Parse("0370636f-77f0-4351-9590-47cb5dd399d4"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), OutboundDate = new DateTime(2018, 10, 17), Name = "JP 80" },
                new Flight { FlightId = Guid.Parse("04f4a5ee-8ba8-4e23-b40f-21f7dffa6f15"), AirlineId = Guid.Parse("0370636f-77f0-4351-9590-47cb5dd399d4"), DepAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 18), Name = "JP 80" },
                new Flight { FlightId = Guid.Parse("769e0a8d-5350-440e-ae1f-7f2c0123f183"), AirlineId = Guid.Parse("0370636f-77f0-4351-9590-47cb5dd399d4"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), OutboundDate = new DateTime(2018, 10, 21), Name = "JP 80" },
                new Flight { FlightId = Guid.Parse("4a1cf6ff-111b-41dd-935d-365ed5c64b35"), AirlineId = Guid.Parse("0370636f-77f0-4351-9590-47cb5dd399d4"), DepAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 22), Name = "JP 80" },
                new Flight { FlightId = Guid.Parse("ba81ca0b-37e9-405a-a7d0-5579b91b26c9"), AirlineId = Guid.Parse("ec4497b8-bc10-422b-bbe5-314dcfd576e0"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 17), Name = "A3 55" },
                new Flight { FlightId = Guid.Parse("79111f2f-a35c-494e-8dd8-b1fae08490d5"), AirlineId = Guid.Parse("ec4497b8-bc10-422b-bbe5-314dcfd576e0"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 18), Name = "A3 55" },
                new Flight { FlightId = Guid.Parse("a988911f-bf2a-49ee-86f6-3f11310d89d2"), AirlineId = Guid.Parse("ec4497b8-bc10-422b-bbe5-314dcfd576e0"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 21), Name = "A3 55" },
                new Flight { FlightId = Guid.Parse("ef4deb19-2caf-49ed-b1a5-89cbd38971d1"), AirlineId = Guid.Parse("ec4497b8-bc10-422b-bbe5-314dcfd576e0"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 22), Name = "A3 55" },
                new Flight { FlightId = Guid.Parse("e13e428a-9ac4-4a5a-b313-893f1a05d1e2"), AirlineId = Guid.Parse("0d6c9207-5ac1-4b72-b0b2-bc407f96b37d"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 17), Name = "EI 77 1" },
                new Flight { FlightId = Guid.Parse("56c131de-4425-4c7b-b939-ef6781af3ce9"), AirlineId = Guid.Parse("0d6c9207-5ac1-4b72-b0b2-bc407f96b37d"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 18), Name = "EI 77 1" },
                new Flight { FlightId = Guid.Parse("70adfe2f-f8b6-4924-8fd4-5709fe7a61d3"), AirlineId = Guid.Parse("0d6c9207-5ac1-4b72-b0b2-bc407f96b37d"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 21), Name = "EI 77 1" },
                new Flight { FlightId = Guid.Parse("d0bebf8b-2b9a-4211-b2bd-9f17e86214aa"), AirlineId = Guid.Parse("0d6c9207-5ac1-4b72-b0b2-bc407f96b37d"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 22), Name = "EI 77 1" },
                new Flight { FlightId = Guid.Parse("04e00301-df49-4686-a325-9f2567a0475f"), AirlineId = Guid.Parse("708ca3f3-e702-43e9-a729-14e4a28c35cf"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 17), Name = "SU 85" },
                new Flight { FlightId = Guid.Parse("64ffb547-7404-4bb7-865e-87eee4d8341c"), AirlineId = Guid.Parse("708ca3f3-e702-43e9-a729-14e4a28c35cf"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 18), Name = "SU 85" },
                new Flight { FlightId = Guid.Parse("c9540468-a56a-4c5f-8898-79579972fbb6"), AirlineId = Guid.Parse("708ca3f3-e702-43e9-a729-14e4a28c35cf"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 21), Name = "SU 85" },
                new Flight { FlightId = Guid.Parse("5d1101fc-875b-4bbe-92e6-7b32e650178b"), AirlineId = Guid.Parse("708ca3f3-e702-43e9-a729-14e4a28c35cf"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 22), Name = "SU 85" },
                new Flight { FlightId = Guid.Parse("0d307539-bdf4-4015-afb7-a3aa826bb6e7"), AirlineId = Guid.Parse("dc0ef059-49f6-497e-954e-b50918fbf033"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 17), Name = "AM 45" },
                new Flight { FlightId = Guid.Parse("636f2116-3323-4062-b20e-007db275e2fa"), AirlineId = Guid.Parse("dc0ef059-49f6-497e-954e-b50918fbf033"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 18), Name = "AM 45" },
                new Flight { FlightId = Guid.Parse("8bad7aec-1bf7-4ba7-8409-e238e77b04c6"), AirlineId = Guid.Parse("dc0ef059-49f6-497e-954e-b50918fbf033"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 21), Name = "AM 45" },
                new Flight { FlightId = Guid.Parse("687c32a5-579a-4270-a872-89197f9fa16d"), AirlineId = Guid.Parse("dc0ef059-49f6-497e-954e-b50918fbf033"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 22), Name = "AM 45" },
                new Flight { FlightId = Guid.Parse("35603c4c-b437-4fd5-b2d2-3df52b7d712b"), AirlineId = Guid.Parse("d8d5389e-5365-4d2f-addd-2d6310e76b4c"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 17), Name = "ZI 33" },
                new Flight { FlightId = Guid.Parse("2cf84e1b-2913-482f-9222-ccdd607e2ea4"), AirlineId = Guid.Parse("d8d5389e-5365-4d2f-addd-2d6310e76b4c"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 18), Name = "ZI 33" },
                new Flight { FlightId = Guid.Parse("30e27bd6-6323-46b4-8c59-b9d63ef66e63"), AirlineId = Guid.Parse("d8d5389e-5365-4d2f-addd-2d6310e76b4c"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 21), Name = "ZI 33" },
                new Flight { FlightId = Guid.Parse("80712587-8a5c-48fa-b583-23f2820460fc"), AirlineId = Guid.Parse("d8d5389e-5365-4d2f-addd-2d6310e76b4c"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 22), Name = "ZI 33" },
                new Flight { FlightId = Guid.Parse("130581cc-0ab2-4360-8f42-2897845e749b"), AirlineId = Guid.Parse("e88a683e-b328-4191-b1f1-c96925045ff9"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 17), Name = "AH 66" },
                new Flight { FlightId = Guid.Parse("04005d46-9675-406b-9768-1783bc68a4c5"), AirlineId = Guid.Parse("e88a683e-b328-4191-b1f1-c96925045ff9"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 18), Name = "AH 66" },
                new Flight { FlightId = Guid.Parse("f32954f3-c790-4ac1-ae65-1d62c6da02de"), AirlineId = Guid.Parse("e88a683e-b328-4191-b1f1-c96925045ff9"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 21), Name = "AH 66" },
                new Flight { FlightId = Guid.Parse("eee9a868-6d91-4b21-8ea2-d5a8c13daef5"), AirlineId = Guid.Parse("e88a683e-b328-4191-b1f1-c96925045ff9"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 22), Name = "AH 66" },
                new Flight { FlightId = Guid.Parse("777d051a-2b08-4dae-8d70-3c72f93fc0ca"), AirlineId = Guid.Parse("90517e3f-9157-4fc3-bef6-de9414d653a1"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 17), Name = "KC 7" },
                new Flight { FlightId = Guid.Parse("7f445f1b-4f1f-49eb-b832-e83730d8fb9f"), AirlineId = Guid.Parse("90517e3f-9157-4fc3-bef6-de9414d653a1"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 18), Name = "KC 7" },
                new Flight { FlightId = Guid.Parse("f22673cc-5c7e-4f5f-86d9-bfd808dad7bf"), AirlineId = Guid.Parse("90517e3f-9157-4fc3-bef6-de9414d653a1"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 21), Name = "KC 7" },
                new Flight { FlightId = Guid.Parse("eca3e05a-d824-4bfc-8d1a-ff7ffb72e1cd"), AirlineId = Guid.Parse("90517e3f-9157-4fc3-bef6-de9414d653a1"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 22), Name = "KC 7" },
                new Flight { FlightId = Guid.Parse("8f4acfb6-4545-4860-aaaf-1d4dcf01e4c1"), AirlineId = Guid.Parse("60dbc0ee-533b-4203-87e4-e5ee27499294"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 17), Name = "UU 43" },
                new Flight { FlightId = Guid.Parse("ebe15e2c-5662-4d8e-a733-b31504a60548"), AirlineId = Guid.Parse("60dbc0ee-533b-4203-87e4-e5ee27499294"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 18), Name = "UU 43" },
                new Flight { FlightId = Guid.Parse("7664ee3c-b188-4987-a4aa-e546ef353ddf"), AirlineId = Guid.Parse("60dbc0ee-533b-4203-87e4-e5ee27499294"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 21), Name = "UU 43" },
                new Flight { FlightId = Guid.Parse("cb427ae9-17fb-4c45-b088-f679834f512e"), AirlineId = Guid.Parse("60dbc0ee-533b-4203-87e4-e5ee27499294"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 22), Name = "UU 43" },
                new Flight { FlightId = Guid.Parse("61e5d609-e482-425d-ae06-a69157ce1ffc"), AirlineId = Guid.Parse("0a5cb398-e644-4bba-92bd-a9769bb2ad5a"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 17), Name = "AC 3" },
                new Flight { FlightId = Guid.Parse("5a6feba8-332c-4175-b040-c80c51a89b82"), AirlineId = Guid.Parse("0a5cb398-e644-4bba-92bd-a9769bb2ad5a"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 18), Name = "AC 3" },
                new Flight { FlightId = Guid.Parse("c5b2e759-67a0-458b-b0a2-e2fc755f4bd2"), AirlineId = Guid.Parse("0a5cb398-e644-4bba-92bd-a9769bb2ad5a"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 21), Name = "AC 3" },
                new Flight { FlightId = Guid.Parse("c73544b9-5c47-4fff-a2c0-01eafab7b692"), AirlineId = Guid.Parse("0a5cb398-e644-4bba-92bd-a9769bb2ad5a"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 22), Name = "AC 3" },
                new Flight { FlightId = Guid.Parse("8a4e50b8-1df5-4865-8db1-2603f22bdcc3"), AirlineId = Guid.Parse("57c600ab-7f06-482f-8937-5342363e1128"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), OutboundDate = new DateTime(2018, 10, 17), Name = "CA 2" },
                new Flight { FlightId = Guid.Parse("40636285-424f-4f58-80b9-e5dcb0c35fb7"), AirlineId = Guid.Parse("57c600ab-7f06-482f-8937-5342363e1128"), DepAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 18), Name = "CA 2" },
                new Flight { FlightId = Guid.Parse("7c9a7a95-c935-401c-b74f-34b921a48846"), AirlineId = Guid.Parse("57c600ab-7f06-482f-8937-5342363e1128"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), OutboundDate = new DateTime(2018, 10, 21), Name = "CA 2" },
                new Flight { FlightId = Guid.Parse("85b5b5a9-8593-4a50-8b7a-22aa62d4ab52"), AirlineId = Guid.Parse("57c600ab-7f06-482f-8937-5342363e1128"), DepAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 22), Name = "CA 2" },
                new Flight { FlightId = Guid.Parse("c8370b6c-0a2d-4719-806d-fd95a60ef398"), AirlineId = Guid.Parse("0be6058c-456b-40d1-88f1-fafc38dcec62"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), OutboundDate = new DateTime(2018, 10, 17), Name = "XK 89" },
                new Flight { FlightId = Guid.Parse("9784433c-ffb1-4a97-b843-77c4fcab60d6"), AirlineId = Guid.Parse("0be6058c-456b-40d1-88f1-fafc38dcec62"), DepAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 18), Name = "XK 89" },
                new Flight { FlightId = Guid.Parse("741fad03-1a0e-4dfb-9e6f-6c025133465f"), AirlineId = Guid.Parse("0be6058c-456b-40d1-88f1-fafc38dcec62"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), OutboundDate = new DateTime(2018, 10, 21), Name = "XK 89" },
                new Flight { FlightId = Guid.Parse("462f3699-f31c-4df8-a5ef-9e7a732254c9"), AirlineId = Guid.Parse("0be6058c-456b-40d1-88f1-fafc38dcec62"), DepAirportId = Guid.Parse("cdc04099-dcdf-4e3c-9ed5-efb14ce8747e"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 22), Name = "XK 89" },
                new Flight { FlightId = Guid.Parse("d9cc8f72-7caf-42dd-afbf-16c6e60b2887"), AirlineId = Guid.Parse("f5b87b06-dfdf-45ee-bcea-6b6a80c3b856"), DepAirportId = Guid.Parse("a701494d-50bc-476b-9fe7-59afbcd22b60"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 17), Name = "UX 6" },
                new Flight { FlightId = Guid.Parse("c93d687d-5b35-4250-8850-1110dc84074f"), AirlineId = Guid.Parse("f5b87b06-dfdf-45ee-bcea-6b6a80c3b856"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("a701494d-50bc-476b-9fe7-59afbcd22b60"), OutboundDate = new DateTime(2018, 10, 18), Name = "UX 6" },
                new Flight { FlightId = Guid.Parse("fad3ee0e-cbfd-41c0-8e7b-81b261ad9d2c"), AirlineId = Guid.Parse("f5b87b06-dfdf-45ee-bcea-6b6a80c3b856"), DepAirportId = Guid.Parse("a701494d-50bc-476b-9fe7-59afbcd22b60"), DesAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), OutboundDate = new DateTime(2018, 10, 21), Name = "UX 6" },
                new Flight { FlightId = Guid.Parse("87ce989d-c1aa-42ff-ae1b-971bb6d1c7d6"), AirlineId = Guid.Parse("f5b87b06-dfdf-45ee-bcea-6b6a80c3b856"), DepAirportId = Guid.Parse("c41a5fed-957e-4084-ae29-178fab95fe95"), DesAirportId = Guid.Parse("a701494d-50bc-476b-9fe7-59afbcd22b60"), OutboundDate = new DateTime(2018, 10, 22), Name = "UX 6" },
                new Flight { FlightId = Guid.Parse("3ba31186-d0ab-4465-b01d-ea59992312d0"), AirlineId = Guid.Parse("9bac5f44-fbdc-469d-ae70-5772aa5798cb"), DepAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 17), Name = "AF 32" },
                new Flight { FlightId = Guid.Parse("9184e347-a964-4890-bdc1-dec961a6f0c5"), AirlineId = Guid.Parse("9bac5f44-fbdc-469d-ae70-5772aa5798cb"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), OutboundDate = new DateTime(2018, 10, 18), Name = "AF 32" },
                new Flight { FlightId = Guid.Parse("4a1fc313-6e97-4753-8ee6-58ff12dc799b"), AirlineId = Guid.Parse("9bac5f44-fbdc-469d-ae70-5772aa5798cb"), DepAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), DesAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), OutboundDate = new DateTime(2018, 10, 21), Name = "AF 32" },
                new Flight { FlightId = Guid.Parse("92b464cc-8092-4068-a91b-7b02aa56ae0a"), AirlineId = Guid.Parse("9bac5f44-fbdc-469d-ae70-5772aa5798cb"), DepAirportId = Guid.Parse("44dc2a79-a656-4fbc-9040-59c935c0f4cb"), DesAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), OutboundDate = new DateTime(2018, 10, 22), Name = "AF 32" },
                new Flight { FlightId = Guid.Parse("10ec2633-97ba-4cda-91b5-65bfd2bb9116"), AirlineId = Guid.Parse("ea1e614f-6418-4b57-93b9-ffe2c360dc1e"), DepAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 17), Name = "AI 1462" },
                new Flight { FlightId = Guid.Parse("4d2eb2f0-5f98-4620-9b4d-cca2ed7b96f4"), AirlineId = Guid.Parse("ea1e614f-6418-4b57-93b9-ffe2c360dc1e"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), OutboundDate = new DateTime(2018, 10, 18), Name = "AI 1462" },
                new Flight { FlightId = Guid.Parse("f8d1865b-aa4e-4b0d-a489-56ab7bf8a3e7"), AirlineId = Guid.Parse("ea1e614f-6418-4b57-93b9-ffe2c360dc1e"), DepAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), DesAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), OutboundDate = new DateTime(2018, 10, 21), Name = "AI 1462" },
                new Flight { FlightId = Guid.Parse("bfb059e7-5525-4e47-84ec-dca846cadad0"), AirlineId = Guid.Parse("ea1e614f-6418-4b57-93b9-ffe2c360dc1e"), DepAirportId = Guid.Parse("282fbb00-2329-49dc-9c05-2d8723f526cb"), DesAirportId = Guid.Parse("99c42e0b-fafc-45f5-bfd2-a8507368eed4"), OutboundDate = new DateTime(2018, 10, 22), Name = "AI 1462" },
                new Flight { FlightId = Guid.Parse("4258b029-5a73-494f-b235-d14c2a463df8"), AirlineId = Guid.Parse("5baadd0c-147b-49d4-8915-f2aee3913c1b"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 17), Name = "FR 6375" },
                new Flight { FlightId = Guid.Parse("cd89723b-d95b-4d69-8323-118e6957117b"), AirlineId = Guid.Parse("5baadd0c-147b-49d4-8915-f2aee3913c1b"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 18), Name = "FR 6375" },
                new Flight { FlightId = Guid.Parse("bc0b58fb-b665-4999-adba-4a327dcc194d"), AirlineId = Guid.Parse("5baadd0c-147b-49d4-8915-f2aee3913c1b"), DepAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 21), Name = "FR 6375" },
                new Flight { FlightId = Guid.Parse("7e227e62-0d18-4204-a95c-564c68dafdeb"), AirlineId = Guid.Parse("5baadd0c-147b-49d4-8915-f2aee3913c1b"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("027c65d4-9cae-4a13-b4be-d5c475c68e12"), OutboundDate = new DateTime(2018, 10, 22), Name = "FR 6375" },
                new Flight { FlightId = Guid.Parse("32900d20-08e7-4ac4-8a73-fc264ada4823"), AirlineId = Guid.Parse("e8beb337-8f58-4270-9eba-3b30bbd42bad"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), OutboundDate = new DateTime(2018, 10, 17), Name = "PC 6541" },
                new Flight { FlightId = Guid.Parse("c12117f6-0bec-4933-b779-685df409da47"), AirlineId = Guid.Parse("e8beb337-8f58-4270-9eba-3b30bbd42bad"), DepAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 18), Name = "PC 6541" },
                new Flight { FlightId = Guid.Parse("12476659-0d57-4b0e-8417-0c9dd0f1db3d"), AirlineId = Guid.Parse("e8beb337-8f58-4270-9eba-3b30bbd42bad"), DepAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), DesAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), OutboundDate = new DateTime(2018, 10, 21), Name = "PC 6541" },
                new Flight { FlightId = Guid.Parse("46cced62-c151-4179-b361-b6f4c4dbd08a"), AirlineId = Guid.Parse("e8beb337-8f58-4270-9eba-3b30bbd42bad"), DepAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), DesAirportId = Guid.Parse("c3dfa85d-e790-4100-8038-a72a0a9d8c5c"), OutboundDate = new DateTime(2018, 10, 22), Name = "PC 6541" },
                new Flight { FlightId = Guid.Parse("8afed154-04c8-4809-ba7b-a3ae00b97494"), AirlineId = Guid.Parse("bcb1cad5-3f5e-4bf1-9c84-bc1c64cdd886"), DepAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), DesAirportId = Guid.Parse("1d9324eb-8593-458e-95e4-8f90bdbc9889"), OutboundDate = new DateTime(2018, 10, 17), Name = "TB 1284" },
                new Flight { FlightId = Guid.Parse("9da96ea0-358a-43ea-86fb-2d39e603428d"), AirlineId = Guid.Parse("bcb1cad5-3f5e-4bf1-9c84-bc1c64cdd886"), DepAirportId = Guid.Parse("1d9324eb-8593-458e-95e4-8f90bdbc9889"), DesAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), OutboundDate = new DateTime(2018, 10, 18), Name = "TB 1284" },
                new Flight { FlightId = Guid.Parse("cb85da03-2fc8-4a43-ba3e-5fb385377159"), AirlineId = Guid.Parse("bcb1cad5-3f5e-4bf1-9c84-bc1c64cdd886"), DepAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), DesAirportId = Guid.Parse("1d9324eb-8593-458e-95e4-8f90bdbc9889"), OutboundDate = new DateTime(2018, 09, 24), Name = "TB 1284" },
                new Flight { FlightId = Guid.Parse("33bd52f1-7231-4e08-85b8-4043d2535ddb"), AirlineId = Guid.Parse("bcb1cad5-3f5e-4bf1-9c84-bc1c64cdd886"), DepAirportId = Guid.Parse("1d9324eb-8593-458e-95e4-8f90bdbc9889"), DesAirportId = Guid.Parse("90b2c78d-a48d-4774-b6af-c0d050739bab"), OutboundDate = new DateTime(2018, 08, 29), Name = "TB 1284" },
                new Flight { FlightId = Guid.Parse("bd655405-2bcf-4674-8519-8dedb3654c97"), AirlineId = Guid.Parse("0fc36598-d9d9-4012-8cc0-407bf535336c"), DepAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 09), Name = "W6 9787" },
                new Flight { FlightId = Guid.Parse("14213f76-9c07-4b46-87f1-3122bade46c8"), AirlineId = Guid.Parse("0fc36598-d9d9-4012-8cc0-407bf535336c"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), OutboundDate = new DateTime(2018, 10, 14), Name = "W6 9787" },
                new Flight { FlightId = Guid.Parse("1c734d7e-8a0a-465b-8096-9a69f222fd3f"), AirlineId = Guid.Parse("0fc36598-d9d9-4012-8cc0-407bf535336c"), DepAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), DesAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), OutboundDate = new DateTime(2018, 10, 02), Name = "W6 9787" },
                new Flight { FlightId = Guid.Parse("8ef7db15-3c29-43f7-8033-c77fd4889f1b"), AirlineId = Guid.Parse("0fc36598-d9d9-4012-8cc0-407bf535336c"), DepAirportId = Guid.Parse("43975900-de93-4613-8ebf-bc291ed50f83"), DesAirportId = Guid.Parse("baefd33d-ad9f-4f2d-ba28-0f7ede282c69"), OutboundDate = new DateTime(2018, 10, 07), Name = "W6 9787" },
            };
            foreach (var e in flights)
            {
                context.Flights.Add(e);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer { CustomerId = Guid.Parse("84357249-0469-4b62-b863-4b8e0a843e86"), CityId = Guid.Parse("37f8ad8c-585d-4a18-ac70-0f9b7f2a3b3d"), FirstName = "Roger", LastName = "Bacon" },
                new Customer { CustomerId = Guid.Parse("73e4a235-75a3-4be3-a509-5e7433e5aba9"), CityId = Guid.Parse("37f8ad8c-585d-4a18-ac70-0f9b7f2a3b3d"), FirstName = "Jeanne", LastName = "Duns Scot" },
                new Customer { CustomerId = Guid.Parse("71c061ea-4d12-446c-8268-32916bfab313"), CityId = Guid.Parse("22cc2f0c-705c-4ca0-b29a-d16db8f5aec3"), FirstName = "Guillaume", LastName = "d'Ockham" },
                new Customer { CustomerId = Guid.Parse("7d91181f-dd29-406d-88ab-e47183f85d93"), CityId = Guid.Parse("22cc2f0c-705c-4ca0-b29a-d16db8f5aec3"), FirstName = "John", LastName = "Locke" },
                new Customer { CustomerId = Guid.Parse("c3d5d457-183b-4f4c-8d58-9a2a9fd3f8c0"), CityId = Guid.Parse("e7846d46-05e4-46ce-aef2-acd684b1b604"), FirstName = "Georgette", LastName = "Berkeley" },
                new Customer { CustomerId = Guid.Parse("63be9316-7849-4124-a439-0430680f289f"), CityId = Guid.Parse("d85148e1-aaac-48ef-9e49-c20b1b76c132"), FirstName = "David", LastName = "Hume" },
            };
            foreach (var e in customers)
            {
                context.Customers.Add(e);
            }
            context.SaveChanges();

            var travels = new Travel[]
            {
                new Travel { OutboundFlightId = Guid.Parse("bd655405-2bcf-4674-8519-8dedb3654c97"), CustomerId = Guid.Parse("84357249-0469-4b62-b863-4b8e0a843e86"), OutboundDate = new DateTime(2018, 10, 09), ReturnFlightId = Guid.Parse("14213f76-9c07-4b46-87f1-3122bade46c8"), ReturnDate = new DateTime(2018, 10, 14), OneWay = false },
                new Travel { OutboundFlightId = Guid.Parse("1c734d7e-8a0a-465b-8096-9a69f222fd3f"), CustomerId = Guid.Parse("73e4a235-75a3-4be3-a509-5e7433e5aba9"), OutboundDate = new DateTime(2018, 10, 02), ReturnFlightId = Guid.Parse("8ef7db15-3c29-43f7-8033-c77fd4889f1b"), ReturnDate = new DateTime(2018, 10, 07), OneWay = false },
                new Travel { OutboundFlightId = Guid.Parse("cb85da03-2fc8-4a43-ba3e-5fb385377159"), CustomerId = Guid.Parse("c3d5d457-183b-4f4c-8d58-9a2a9fd3f8c0"), OutboundDate = new DateTime(2018, 09, 24), OneWay = true },
                new Travel { OutboundFlightId = Guid.Parse("33bd52f1-7231-4e08-85b8-4043d2535ddb"), CustomerId = Guid.Parse("63be9316-7849-4124-a439-0430680f289f"), OutboundDate = new DateTime(2018, 08, 29), OneWay = true },
            };
            foreach (var e in travels)
            {
                context.Travels.Add(e);
            }
            context.SaveChanges();
        }
    }
}
