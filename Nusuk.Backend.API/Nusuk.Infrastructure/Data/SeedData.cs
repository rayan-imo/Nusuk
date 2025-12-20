using Nusuk.Core.Entities;


namespace Nusuk.Infrastructure.Data
{
    public class SeedData
    {  // Caravans
        public readonly Guid Caravan1 = Guid.Parse("70000000-0000-0000-0000-000000000001");
        public readonly Guid Caravan2 = Guid.Parse("70000000-0000-0000-0000-000000000002");
        public readonly Guid Caravan3 = Guid.Parse("70000000-0000-0000-0000-000000000003");
        // Trips
        public readonly Guid Trip1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public readonly Guid Trip2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
        public readonly Guid Trip3 = Guid.Parse("33333333-3333-3333-3333-333333333333");

        // Packages
        public readonly Guid Package1 = Guid.Parse("aaaa1111-1111-1111-1111-111111111111");
        public readonly Guid Package2 = Guid.Parse("aaaa2222-2222-2222-2222-222222222222");
        public readonly Guid Package3 = Guid.Parse("aaaa3333-3333-3333-3333-333333333333");

        // Services
        public readonly Guid[] Services =
        {
            Guid.Parse("00010000-0000-0000-0000-000000000001"),
            Guid.Parse("00010000-0000-0000-0000-000000000002"),
            Guid.Parse("00010000-0000-0000-0000-000000000003"),
            Guid.Parse("00010000-0000-0000-0000-000000000004"),

            Guid.Parse("00020000-0000-0000-0000-000000000001"),
            Guid.Parse("00020000-0000-0000-0000-000000000002"),
            Guid.Parse("00020000-0000-0000-0000-000000000003"),
            Guid.Parse("00020000-0000-0000-0000-000000000004"),

            Guid.Parse("00030000-0000-0000-0000-000000000001"),
            Guid.Parse("00030000-0000-0000-0000-000000000002"),
            Guid.Parse("00030000-0000-0000-0000-000000000003"),
            Guid.Parse("00030000-0000-0000-0000-000000000004")
        };

        // ServiceDetail IDs
        public readonly Guid[] ServiceDetailIds =
        {
            Guid.Parse("50000000-0000-0000-0000-000000000001"),
            Guid.Parse("50000000-0000-0000-0000-000000000002"),
            Guid.Parse("50000000-0000-0000-0000-000000000003"),
            Guid.Parse("50000000-0000-0000-0000-000000000004"),

            Guid.Parse("50000000-0000-0000-0000-000000000005"),
            Guid.Parse("50000000-0000-0000-0000-000000000006"),
            Guid.Parse("50000000-0000-0000-0000-000000000007"),
            Guid.Parse("50000000-0000-0000-0000-000000000008"),

            Guid.Parse("50000000-0000-0000-0000-000000000009"),
            Guid.Parse("50000000-0000-0000-0000-000000000010"),
            Guid.Parse("50000000-0000-0000-0000-000000000011"),
            Guid.Parse("50000000-0000-0000-0000-000000000012")
        };

        // TripPackage IDs
        public readonly Guid[] TripPackageIds =
        {
            Guid.Parse("60000000-0000-0000-0000-000000000001"),
            Guid.Parse("60000000-0000-0000-0000-000000000002"),
            Guid.Parse("60000000-0000-0000-0000-000000000003")
        };


      
        // TRIPS
 
        public List<Trip> GetTrips() => new()
        {
            new Trip { Id = Trip1, Name = "عمرة رمضان", Description = "المدة 10 أيام" },
            new Trip { Id = Trip2, Name = "برنامج الحج المتميز", Description = "المدة 20 يوم" },
            new Trip { Id = Trip3, Name = "عمرة العائلة الذهبية", Description = "المدة 14 يوم" }
        };

        
        // PACKAGES
       
        public List<Package> GetPackages() => new()
        {
            new Package { Id = Package1, Name = "باقة عمرة رمضان", TotalPrice = 12500 },
            new Package { Id = Package2, Name = "باقة الحج المتميز", TotalPrice = 35000 },
            new Package { Id = Package3, Name = "باقة عمرة العائلة الذهبية", TotalPrice = 18500 }
        };

      
        // SERVICES
  
        public List<Service> GetServices() => new()
        {
            // Trip 1 Services
            new Service { Id = Services[0], Name = "طيران", Description = "مباشر درجة أعمال" },

new Service { Id = Services[1], Name = "فندق", Description = "خمسة نجوم على بعد 200م" },
            new Service { Id = Services[2], Name = "مواصلات", Description = "فاخرة مع مرشدين" },
            new Service { Id = Services[3], Name = "وجبات", Description = "إفطار وسحور شامل" },

            // Trip 2 Services
            new Service { Id = Services[4], Name = "طيران", Description = "مباشر مع امتعة 50 كجم" },
            new Service { Id = Services[5], Name = "فندق", Description = "خمسة نجوم مكة والمدينة" },
            new Service { Id = Services[6], Name = "مرافق ديني", Description = "متخصص طوال الرحلة" },
            new Service { Id = Services[7], Name = "حافلات", Description = "مكيفة مع توصيل" },

            // Trip 3 Services
            new Service { Id = Services[8], Name = "طيران", Description = "تذاكر عائلية" },
            new Service { Id = Services[9], Name = "فندق", Description = "غرف متصلة 4 نجوم" },
            new Service { Id = Services[10], Name = "أنشطة للأطفال", Description = "خاصة بالأطفال" },
            new Service { Id = Services[11], Name = "مواصلات", Description = "سيارة خاصة" }
        };

        
        // TRIP_PACKAGE
    
        public List<TripPackage> GetTripPackages() => new()
        {
            new TripPackage { Id = TripPackageIds[0], TripId = Trip1, PackageId = Package1 },
            new TripPackage { Id = TripPackageIds[1], TripId = Trip2, PackageId = Package2 },
            new TripPackage { Id = TripPackageIds[2], TripId = Trip3, PackageId = Package3 }
        };

       
        // PACKAGE_SERVICE

        public List<ServiceDetail> GetServiceDetails() => new()
        {
            // Package1 (Trip1)
            new ServiceDetail { Id = ServiceDetailIds[0], PackageId = Package1, ServiceId = Services[0] },
            new ServiceDetail { Id = ServiceDetailIds[1], PackageId = Package1, ServiceId = Services[1] },
            new ServiceDetail { Id = ServiceDetailIds[2], PackageId = Package1, ServiceId = Services[2] },
            new ServiceDetail { Id = ServiceDetailIds[3], PackageId = Package1, ServiceId = Services[3] },

            // Package2 (Trip2)
            new ServiceDetail { Id = ServiceDetailIds[4], PackageId = Package2, ServiceId = Services[4] },
            new ServiceDetail { Id = ServiceDetailIds[5], PackageId = Package2, ServiceId = Services[5] },
            new ServiceDetail { Id = ServiceDetailIds[6], PackageId = Package2, ServiceId = Services[6] },
            new ServiceDetail { Id = ServiceDetailIds[7], PackageId = Package2, ServiceId = Services[7] },

            // Package3 (Trip3)
            new ServiceDetail { Id = ServiceDetailIds[8], PackageId = Package3, ServiceId = Services[8] },
            new ServiceDetail { Id = ServiceDetailIds[9], PackageId = Package3, ServiceId = Services[9] },
            new ServiceDetail { Id = ServiceDetailIds[10], PackageId = Package3, ServiceId = Services[10] },
            new ServiceDetail { Id = ServiceDetailIds[11], PackageId = Package3, ServiceId = Services[11] }
        };
        public List<Caravan> GetCaravans() => new()
        {
            new Caravan
            {
               Id = Caravan1,
              TripPackageId=TripPackageIds[0],
            },
            new Caravan
            {
              Id = Caravan2,
              TripPackageId=TripPackageIds[1]
            },
           new Caravan
           {
             Id = Caravan3,
             TripPackageId=TripPackageIds[2]
           }
        };
    }
}


