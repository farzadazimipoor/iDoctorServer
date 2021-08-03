using AN.Core.Domain;
using AN.DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AN.DAL
{
    public class BanobatDbContext : DbContext
    {
        public BanobatDbContext()
        {

        }

        public BanobatDbContext(DbContextOptions<BanobatDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("an");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasIndex(u => u.Mobile).IsUnique();

            modelBuilder.Entity<Person>().HasIndex(u => u.UniqueId).IsUnique();

            modelBuilder.Entity<Resource>().HasIndex(u => u.Key).IsUnique();

            modelBuilder.Entity<VocationDay>().HasIndex(u => u.Date).IsUnique();

            modelBuilder.Entity<Appointment>().HasIndex(u => u.UniqueTrackingCode).IsUnique();

            modelBuilder.Entity<Offer>().HasIndex(u => u.Code).IsUnique();

            EnableSoftDelete(modelBuilder);

            LoadConfigs(modelBuilder);

            SeedInitialData(modelBuilder);
        }

        #region Db Sets
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<ClinicPersons> ClinicPersons { get; set; }
        public virtual DbSet<ExpertiseCategory> ExpertiseCategories { get; set; }
        public virtual DbSet<Expertise> Expertises { get; set; }
        public virtual DbSet<DoctorExpertise> DoctorExpertises { get; set; }
        public virtual DbSet<ScientificCategory> ScientificCategories { get; set; }
        public virtual DbSet<AdditionalExpertise> AdditionalExpertises { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<VocationDay> VocationDays { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<HospitalPersons> HospitalPersons { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<PatientInsurance> PatientInsurances { get; set; }
        public virtual DbSet<PaymentInfo> PaymentInfoes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ShiftCenter> ShiftCenters { get; set; }
        public virtual DbSet<ShiftCenterPersons> ShiftCenterPersons { get; set; }
        public virtual DbSet<ShiftCenterMessage> PoliclinicMessages { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ServiceSupply> ServiceSupplies { get; set; }
        public virtual DbSet<ServiceSupplyInfo> ServiceSupplyInfo { get; set; }
        public virtual DbSet<PatientPersonInfo> PatientPersonInfo { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<BlockedIp> BlockedIps { get; set; }
        public virtual DbSet<Statistics> Statisticses { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ShiftCenterService> CenterServices { get; set; }
        public virtual DbSet<BlockedMobiles> BlockedMobiles { get; set; }
        public virtual DbSet<DoctorActivityLog> DoctorActivityLogs { get; set; }
        public virtual DbSet<UsualSchedulePlan> UsualSchedulePlans { get; set; }
        public virtual DbSet<UsualScheduleInsurances> UsualScheduleInsurances { get; set; }
        public virtual DbSet<TreatmentHistory> TreatmentHistories { get; set; }
        public virtual DbSet<PharmaceuticalGroup> PharmaceuticalGroups { get; set; }
        public virtual DbSet<DrugGroups> DrugGroups { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<TreatmentsItems> TreatmentsItems { get; set; }
        public virtual DbSet<ServiceSupplyRating> ServiceSupplyRatings { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<IdentityUser> IdentityUsers { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<PharmacyPrescription> PharmacyPrescriptions { get; set; }
        public virtual DbSet<PharmacyDoneTreatments> PharmacyDoneTreatments { get; set; }
        public virtual DbSet<CenterPrescription> SonarPrescriptions { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<PastMedicalHistory> PastMedicalHistories { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<DoctorScientificCategory> DoctorScientificCategories { get; set; }
        public virtual DbSet<ContentCategory> ContentCategories { get; set; }
        public virtual DbSet<ContentArticle> ContentArticles { get; set; }
        public virtual DbSet<Consultancy> Consultancies { get; set; }
        public virtual DbSet<ConsultancyMessage> ConsultancyMessages { get; set; }
        public virtual DbSet<InsuranceService> InsuranceServices { get; set; }
        public virtual DbSet<DiseaseRecordsForm> DiseaseRecordsForms { get; set; }
        public virtual DbSet<MedicalRequest> MedicalRequests { get; set; }
        #endregion

        private void LoadConfigs(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new AdditionalExpertiseConfiguration())
                .ApplyConfiguration(new AppointmentConfiguration())
                .ApplyConfiguration(new BlockedIpConfiguration())
                .ApplyConfiguration(new BlockedMobilesConfiguration())
                .ApplyConfiguration(new CityConfiguration())
                .ApplyConfiguration(new ClinicConfiguration())
                .ApplyConfiguration(new ClinicPersonsConfiguration())
                .ApplyConfiguration(new ContactUsConfiguration())
                .ApplyConfiguration(new CountryConfiguration())
                .ApplyConfiguration(new DoctorActivityLogConfiguration())
                .ApplyConfiguration(new DoctorExpertiseConfiguration())
                .ApplyConfiguration(new DrugConfiguration())
                .ApplyConfiguration(new DrugGroupsConfiguration())
                .ApplyConfiguration(new ExpertiseCategoryConfiguration())
                .ApplyConfiguration(new ExpertiseConfiguration())
                .ApplyConfiguration(new ServiceConfiguration())
                .ApplyConfiguration(new HospitalConfiguration())
                .ApplyConfiguration(new HospitalPersonsConfiguration())
                .ApplyConfiguration(new PaymentInfoConfiguration())
                .ApplyConfiguration(new PharmaceuticalGroupConfiguration())
                .ApplyConfiguration(new ShiftCenterConfiguration())
                .ApplyConfiguration(new ShiftCenterMessageConfiguration())
                .ApplyConfiguration(new ShiftCenterPersonsConfiguration())
                .ApplyConfiguration(new ShiftCenterServiceConfiguration())
                .ApplyConfiguration(new ProvinceConfiguration())
                .ApplyConfiguration(new ResourceConfiguration())
                .ApplyConfiguration(new ScheduleConfiguration())
                .ApplyConfiguration(new ScientificCategoryConfiguration())
                .ApplyConfiguration(new ServiceSupplyConfiguration())
                .ApplyConfiguration(new StatisticsConfiguration())
                .ApplyConfiguration(new TreatmentHistoryConfiguration())
                .ApplyConfiguration(new TreatmentsItemsConfiguration())
                .ApplyConfiguration(new PersonConfiguration())
                .ApplyConfiguration(new ServiceSupplyInfoConfiguration())
                .ApplyConfiguration(new PatientPersonInfoConfiguration())
                .ApplyConfiguration(new UsualScheduleInsurancesConfiguration())
                .ApplyConfiguration(new UsualSchedulePlanConfiguration())
                .ApplyConfiguration(new VocationDayConfiguration())
                .ApplyConfiguration(new ServiceSupplyRatingConfiguration())
                .ApplyConfiguration(new AttachmentConfiguration())
                .ApplyConfiguration(new OfferConfiguration())
                .ApplyConfiguration(new EventLogConfiguration())
                .ApplyConfiguration(new ServiceCategoryConfiguration())
                .ApplyConfiguration(new IdentityUserConfiguration())
                .ApplyConfiguration(new PharmacyConfiguration())
                .ApplyConfiguration(new PharmacyPrescriptionConfiguration())
                .ApplyConfiguration(new PharmacyDoneTreatmentsConfiguration())
                .ApplyConfiguration(new CenterPrescriptionConfiguration())
                .ApplyConfiguration(new PatientConfiguration())
                .ApplyConfiguration(new InvoiceConfiguration())
                .ApplyConfiguration(new InvoiceItemConfiguration())
                .ApplyConfiguration(new PastMedicalHistoryConfiguration())
                .ApplyConfiguration(new NotificationConfiguration())
                .ApplyConfiguration(new DoctorScientificCategoryConfiguration())
                .ApplyConfiguration(new ContentCategoryConfiguration())
                .ApplyConfiguration(new ContentArticleConfiguration())
                .ApplyConfiguration(new ConsultancyConfiguration())
                .ApplyConfiguration(new ConsultancyMessageConfiguration())
                .ApplyConfiguration(new InsuranceBranchConfiguration())
                .ApplyConfiguration(new InsuranceConfiguration())
                .ApplyConfiguration(new InsuranceServiceConfiguration())
                .ApplyConfiguration(new PatientInsuranceConfiguration())
                .ApplyConfiguration(new ScheduleInsuranceConfiguration())
                .ApplyConfiguration(new ServiceSupplyInsuranceConfiguration())
                .ApplyConfiguration(new DiseaseRecordsFormConfiguration())
                .ApplyConfiguration(new MedicalRequestConfiguration());
        }

        private void EnableSoftDelete(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var parameter = Expression.Parameter(entityType.ClrType);

                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));

                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                var compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            #region Places
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                     Id = 1,
                     Name = "Germany",
                     Name_Ku = "ئاڵمانیا",
                     Name_Ar = "ألمانيا",
                     Code = "DE",
                     Type = Core.Enums.CountryType.International,
                     CreatedAt = DateTime.Now,
                },
                new Country
                {
                    Id = 2,
                    Name = "India",
                    Name_Ku = "هیند",
                    Name_Ar = "الهند",
                    Code = "IN",
                    Type = Core.Enums.CountryType.International,
                    CreatedAt = DateTime.Now,
                },
                new Country
                {
                    Id = 3,
                    Name = "Turkey",
                    Name_Ku = "تورکیا",
                    Name_Ar = "تركيا",
                    Code = "TR",
                    Type = Core.Enums.CountryType.International,
                    CreatedAt = DateTime.Now,
                },
                new Country
                {
                    Id = 4,
                    Name = "Jordan",
                    Name_Ku = "ئوردن",
                    Name_Ar = "اردن",
                    Code = "JO",
                    Type = Core.Enums.CountryType.International,
                    CreatedAt = DateTime.Now,
                },
                new Country
                {
                    Id = 5,
                    Name = "Erbil",
                    Name_Ku = "هەولێر",
                    Name_Ar = "اربیل",
                    Type = Core.Enums.CountryType.Domestic,
                    CreatedAt = DateTime.Now,
                },
                new Country
                {
                    Id = 6,
                    Name = "Sulaymaniyah",
                    Name_Ku = "سلێمانی",
                    Name_Ar = "السلیمانیه",
                    Type = Core.Enums.CountryType.Domestic,
                    CreatedAt = DateTime.Now,
                },
                new Country
                {
                    Id = 7,
                    Name = "Dahuk",
                    Name_Ku = "دهۆک",
                    Name_Ar = "دهوك",
                    Type = Core.Enums.CountryType.Domestic,
                    CreatedAt = DateTime.Now,
                }
            );
            var erbilProvinceId = 1;
            var slemaniProvinceId = 2;
            var dahoukProvinceId = 3;
            modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    Id = erbilProvinceId,
                    Name = "Erbil",
                    Name_Ku = "هەولێر",
                    Name_Ar = "اربیل",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Province
                {
                    Id = slemaniProvinceId,
                    Name = "Sulaymaniyah",
                    Name_Ku = "سلێمانی",
                    Name_Ar = "السلیمانیه",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Province
                {
                    Id = dahoukProvinceId,
                    Name = "Dahuk",
                    Name_Ku = "دهۆک",
                    Name_Ar = "دهوك",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    ProvinceId = erbilProvinceId,
                    Name = "Erbil",
                    Name_Ku = "هەولێر",
                    Name_Ar = "اربیل",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new City
                {
                    Id = 2,
                    ProvinceId = slemaniProvinceId,
                    Name = "Sulaymaniyah",
                    Name_Ku = "سلێمانی",
                    Name_Ar = "السلیمانیه",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new City
                {
                    Id = 3,
                    ProvinceId = dahoukProvinceId,
                    Name = "Dahuk",
                    Name_Ku = "دهۆک",
                    Name_Ar = "دهوك",
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );
            #endregion

            #region SERVICES
            // Doctors
            var healthServicesCategoryId = 1;

            // Beauty Centers
            var faceServicesCategoryId = 2;
            var makeupServicesCategoryId = 3;
            var bodyServicesCategoryId = 4;
            var hairServicesCategoryId = 5;
            var laserServicesCategoryId = 6;
            var nailServicesCategoryId = 7;
            var fillerAndBotaxServicesCategoryId = 8;

            // Dentists
            var dentistServicesCategoryId = 9;

            // Salon
            var salonFaceServicesCategoryId = 10;
            var salonMakeupServicesCategoryId = 11;
            var salonHairServicesCategoryId = 12;
            var salonLaserServicesCategoryId = 13;
            var salonNailServicesCategoryId = 14;

            // Healthy LifeStyle
            var healthyLifeStyleServicesCategoryId = 15;

            // HomeCare
            var homeCareCovidServicesCategoryId = 16;
            var homeCareNormalCasesServicesCategoryId = 17;
            var homeCareAmbulanceServicesCategoryId = 18;
            var homeCarePhysiotherapyServicesCategoryId = 19;
            var homeCareLaboratoryServicesCategoryId = 20;
            var homeCareMedicinesServicesCategoryId = 21;

            var barberServicesCategoryId = 22;

            modelBuilder.Entity<ServiceCategory>().HasData(
                #region Cats
                new ServiceCategory
                {
                    Id = healthServicesCategoryId,
                    Name = "Health",
                    Name_Ku = "تەندروستی",
                    Name_Ar = "الصحة",
                    CenterType = Core.Enums.ShiftCenterType.Polyclinic,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = faceServicesCategoryId,
                    Name = "Face",
                    Name_Ku = "دەموچاو",
                    Name_Ar = "الوجه",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = makeupServicesCategoryId,
                    Name = "Makeup",
                    Name_Ku = "مكياج",
                    Name_Ar = "مكياج",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = bodyServicesCategoryId,
                    Name = "Body",
                    Name_Ku = "جەستە",
                    Name_Ar = "الجسم",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = hairServicesCategoryId,
                    Name = "Hair",
                    Name_Ku = "پرچ",
                    Name_Ar = "الشعر",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = laserServicesCategoryId,
                    Name = "Laser",
                    Name_Ku = "لەیز‌ەر",
                    Name_Ar = "ليزر",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = nailServicesCategoryId,
                    Name = "Nail",
                    Name_Ku = "نینۆک",
                    Name_Ar = "الأضافر",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new ServiceCategory
                {
                    Id = fillerAndBotaxServicesCategoryId,
                    Name = "Filler & Botox",
                    Name_Ku = "فلر و بوتوكس",
                    Name_Ar = "فلر و بوتوكس",
                    CenterType = Core.Enums.ShiftCenterType.BeautyCenter,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },

                // Dentists
                new ServiceCategory
                {
                    Id = dentistServicesCategoryId,
                    Name = "Dentist",
                    Name_Ku = "ددان",
                    Name_Ar = "Dentist",
                    CenterType = Core.Enums.ShiftCenterType.Dentist,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                },

                // Salon
                // new ServiceCategory
                //{
                //    Id = salonFaceServicesCategoryId,
                //    Name = "Face",
                //    Name_Ku = "دەموچاو",
                //    Name_Ar = "الوجه",
                //    CenterType = Core.Enums.ShiftCenterType.Salon,
                //    CreatedAt = DateTime.Now,
                //    IsDeleted = false
                //},
                // new ServiceCategory
                // {
                //     Id = salonMakeupServicesCategoryId,
                //     Name = "Makeup",
                //     Name_Ku = "مكياج",
                //     Name_Ar = "مكياج",
                //     CenterType = Core.Enums.ShiftCenterType.Salon,
                //     CreatedAt = DateTime.Now,
                //     IsDeleted = false
                // },
                // new ServiceCategory
                // {
                //     Id = salonHairServicesCategoryId,
                //     Name = "Hair",
                //     Name_Ku = "پرچ",
                //     Name_Ar = "الشعر",
                //     CenterType = Core.Enums.ShiftCenterType.Salon,
                //     CreatedAt = DateTime.Now,
                //     IsDeleted = false
                // },
                // new ServiceCategory
                // {
                //     Id = salonLaserServicesCategoryId,
                //     Name = "Laser",
                //     Name_Ku = "لەیز‌ەر",
                //     Name_Ar = "ليزر",
                //     CenterType = Core.Enums.ShiftCenterType.Salon,
                //     CreatedAt = DateTime.Now,
                //     IsDeleted = false
                // },
                // new ServiceCategory
                // {
                //     Id = salonNailServicesCategoryId,
                //     Name = "Nail",
                //     Name_Ku = "نینۆک",
                //     Name_Ar = "الأضافر",
                //     CenterType = Core.Enums.ShiftCenterType.Salon,
                //     CreatedAt = DateTime.Now,
                //     IsDeleted = false
                // },
                 new ServiceCategory
                 {
                     Id = healthyLifeStyleServicesCategoryId,
                     Name = "Healthy Lifestyle",
                     Name_Ku = "سەنتەری تەندروستی",
                     Name_Ar = "أنماط الحیاة صحي",
                     CenterType = Core.Enums.ShiftCenterType.HealthyLifeStyle,
                     CreatedAt = DateTime.Now,
                     IsDeleted = false
                 },
            #endregion

               // HomeCare
               new ServiceCategory
               {
                   Id = homeCareCovidServicesCategoryId,
                   Name = "Covid-19 Services",
                   Name_Ku = "خزمەتگوزارییەکانی تایبەت بە کۆڤید",
                   Name_Ar = "خدمات كوفيد-١٩",
                   CenterType = Core.Enums.ShiftCenterType.HomeCare,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               },
               new ServiceCategory
               {
                   Id = homeCareNormalCasesServicesCategoryId,
                   Name = "Normal Case Services Non-Covid Cases",
                   Name_Ku = "خزمەتگوزارییەکانی تایبەت بە نەخۆشی ئاسایی",
                   Name_Ar = "الحالات غير المقدمة لخدمات الحالات العادية",
                   CenterType = Core.Enums.ShiftCenterType.HomeCare,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               },
               new ServiceCategory
               {
                   Id = homeCareAmbulanceServicesCategoryId,
                   Name = "Ambulance",
                   Name_Ku = "ئەمبولانس",
                   Name_Ar = "ئەمبوڵانس",
                   CenterType = Core.Enums.ShiftCenterType.HomeCare,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               },
               new ServiceCategory
               {
                   Id = homeCarePhysiotherapyServicesCategoryId,
                   Name = "Physiotherapy",
                   Name_Ku = "چاره‌سه‌ری سروشتی",
                   Name_Ar = "العلاج الطبيعي",
                   CenterType = Core.Enums.ShiftCenterType.HomeCare,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               },
               new ServiceCategory
               {
                   Id = homeCareLaboratoryServicesCategoryId,
                   Name = "Laboratory",
                   Name_Ku = "پشکنینی خوێن",
                   Name_Ar = "المختبر",
                   CenterType = Core.Enums.ShiftCenterType.HomeCare,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               },
               new ServiceCategory
               {
                   Id = homeCareMedicinesServicesCategoryId,
                   Name = "Medicines",
                   Name_Ku = "دەرمان",
                   Name_Ar = "الادويه",
                   CenterType = Core.Enums.ShiftCenterType.HomeCare,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               }

               // Barber
               /*new ServiceCategory
               {
                   Id = barberServicesCategoryId,
                   Name = "Barber",
                   Name_Ku = "سەرتاش",
                   Name_Ar = "حلاق",
                   CenterType = Core.Enums.ShiftCenterType.Barber,
                   CreatedAt = DateTime.Now,
                   IsDeleted = false
               }*/
            );

            #region COMMON HEALTH SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 1,
                       ServiceCategoryId = healthServicesCategoryId,
                       Name = "Visit",
                       Name_Ku = "ڤیزیت",
                       Name_Ar = "يزور",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region FACE SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 2,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Hydrofacial",
                       Name_Ku = "Hydrofacial",
                       Name_Ar = "الهايدرا فيشيل",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 3,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Scarlet",
                       Name_Ku = "Scarlet",
                       Name_Ar = "سكارليت",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 4,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Hypho",
                       Name_Ku = "Hypho",
                       Name_Ar = "هايفو",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 5,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "PRP",
                       Name_Ku = "PRP",
                       Name_Ar = "بلازما - PRP",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 6,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Mesotherapy",
                       Name_Ku = "Mesotherapy",
                       Name_Ar = "بلازماميزو",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 7,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Thread face lifting",
                       Name_Ku = "هەڵگرتنی مووی دەمو چاو",
                       Name_Ar = "شد الوجه بالخيوط",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 8,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Eyebrow lifting",
                       Name_Ku = "برۆ کردن",
                       Name_Ar = "رفع الحاجب",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 9,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Pigmentation treatment",
                       Name_Ku = "Pigmentation treatment",
                       Name_Ar = "علاج التصبغات",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 10,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Acne & acne scar management",
                       Name_Ku = "Acne & acne scar management",
                       Name_Ar = "علاج ندبات حب الشباب",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 11,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Nose reconstruction",
                       Name_Ku = "Nose reconstruction",
                       Name_Ar = "عملية تجميل الأنف",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 12,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Nevus removal",
                       Name_Ku = "Nevus removal",
                       Name_Ar = "إزالة الشامة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 13,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Carbon laser",
                       Name_Ku = "Carbon laser",
                       Name_Ar = "ليزر كربوني",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 14,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Eyebrow tatoo",
                       Name_Ku = "تاتۆی برۆ",
                       Name_Ar = "تاتو الحواجب",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 15,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "face Adjustments",
                       Name_Ku = "face Adjustments",
                       Name_Ar = "تعديل الوجه",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 16,
                       ServiceCategoryId = faceServicesCategoryId,
                       Name = "Eyebrow Extention",
                       Name_Ku = "ئێکستێنشنی برۆ",
                       Name_Ar = "إكستنشن الرموش ",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region MAKEUP SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 17,
                       ServiceCategoryId = makeupServicesCategoryId,
                       Name = "Full makeup",
                       Name_Ku = "مکیاج کامل",
                       Name_Ar = "مكياج سهرة/ ثقيل",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 18,
                       ServiceCategoryId = makeupServicesCategoryId,
                       Name = "Simple makeup",
                       Name_Ku = "مکیاجی سادە",
                       Name_Ar = "مكياج ناعم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region BODY SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 19,
                       ServiceCategoryId = bodyServicesCategoryId,
                       Name = "Sculpture",
                       Name_Ku = "Sculpture",
                       Name_Ar = "نحت الجسم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 20,
                       ServiceCategoryId = bodyServicesCategoryId,
                       Name = "Body contouring",
                       Name_Ku = "Body contouring",
                       Name_Ar = "Body contouring",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region HAIR SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 21,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Keratin",
                       Name_Ku = "کیراتین",
                       Name_Ar = "كرياتين",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 22,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Mask",
                       Name_Ku = "ماسک",
                       Name_Ar = "ماسك",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 23,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Hair falling treatment",
                       Name_Ku = "چارەسەری قژ وەرین",
                       Name_Ar = "علاج تساقط الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 24,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Hair transplant",
                       Name_Ku = "چاندنی پرچ",
                       Name_Ar = "زرع الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 25,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Hair extension",
                       Name_Ku = "ئیکستێنشن",
                       Name_Ar = "إكستنشن الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 26,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Dye",
                       Name_Ku = "ڕەنگ کردن",
                       Name_Ar = "صبغ",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 27,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Hair Styling",
                       Name_Ku = "ڕازاندنەوەی قژ",
                       Name_Ar = "تسريحة شعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 28,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Hair root dye",
                       Name_Ku = "ڕەنگ کردنی ڕیشەی قژ",
                       Name_Ar = "صبغ اطراف الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 29,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "Cutting",
                       Name_Ku = "قژ بڕین",
                       Name_Ar = "قص شعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 30,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "سشوار",
                       Name_Ku = "سێشوار",
                       Name_Ar = "سشوار",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 31,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "موهير",
                       Name_Ku = "موهير",
                       Name_Ar = "موهير",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 32,
                       ServiceCategoryId = hairServicesCategoryId,
                       Name = "اونبرة",
                       Name_Ku = "ئۆمبر",
                       Name_Ar = "اونبرة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region LASER SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 33,
                       ServiceCategoryId = laserServicesCategoryId,
                       Name = "Full body",
                       Name_Ku = "تەواوی لەش",
                       Name_Ar = "كامل الجسم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 34,
                       ServiceCategoryId = laserServicesCategoryId,
                       Name = "Face",
                       Name_Ku = "دەمو چاو",
                       Name_Ar = "الوجه",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region NAIL SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 35,
                       ServiceCategoryId = nailServicesCategoryId,
                       Name = "Manicure",
                       Name_Ku = "مانیکیور",
                       Name_Ar = "منيكير",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 36,
                       ServiceCategoryId = nailServicesCategoryId,
                       Name = "Pedicure",
                       Name_Ku = "پێدیکیور",
                       Name_Ar = "بديكير",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 37,
                       ServiceCategoryId = nailServicesCategoryId,
                       Name = "Gel",
                       Name_Ku = "جێل",
                       Name_Ar = "جلّ الأظافر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 38,
                       ServiceCategoryId = nailServicesCategoryId,
                       Name = "Acrylic",
                       Name_Ku = "ئاکریلیک",
                       Name_Ar = "آكريليك",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region FILLER & BOTOX SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 39,
                       ServiceCategoryId = fillerAndBotaxServicesCategoryId,
                       Name = "Face",
                       Name_Ku = "Face",
                       Name_Ar = "الوجه",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 40,
                       ServiceCategoryId = fillerAndBotaxServicesCategoryId,
                       Name = "Body",
                       Name_Ku = "Body",
                       Name_Ar = "الجسم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region DENTIST SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 41,
                       ServiceCategoryId = dentistServicesCategoryId,
                       Name = "Complete examination",
                       Name_Ku = "پشکنینی گشتی",
                       Name_Ar = "Complete examination",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 42,
                       ServiceCategoryId = dentistServicesCategoryId,
                       Name = "Dental cleanings",
                       Name_Ku = "خاوێن کردنەوەی ددان",
                       Name_Ar = "Dental cleanings",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 43,
                       ServiceCategoryId = dentistServicesCategoryId,
                       Name = "Visit",
                       Name_Ku = "ڤیزیت",
                       Name_Ar = "يزور",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region SALON-FACE SERVICES
            modelBuilder.Entity<Service>().HasData(
                  new Service
                  {
                      Id = 44,
                      ServiceCategoryId = salonFaceServicesCategoryId,
                      Name = "Thread face lifting",
                      Name_Ku = "Thread face lifting",
                      Name_Ar = "شد الوجه بالخيوط",
                      CreatedAt = DateTime.Now,
                      IsDeleted = false
                  },
                  new Service
                  {
                      Id = 45,
                      ServiceCategoryId = salonFaceServicesCategoryId,
                      Name = "Eyebrow lifting",
                      Name_Ku = "Eyebrow lifting",
                      Name_Ar = "رفع الحاجب",
                      CreatedAt = DateTime.Now,
                      IsDeleted = false
                  },
                   new Service
                   {
                       Id = 46,
                       ServiceCategoryId = salonFaceServicesCategoryId,
                       Name = "Eyebrow tatoo",
                       Name_Ku = "Eyebrow tatoo ",
                       Name_Ar = "تاتو الحواجب",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 47,
                       ServiceCategoryId = salonFaceServicesCategoryId,
                       Name = "Eyebrow Extention",
                       Name_Ku = "Eyebrow Extention",
                       Name_Ar = "إكستنشن الرموش ",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
              );
            #endregion

            #region SALON-MAKEUP SERVICES
            modelBuilder.Entity<Service>().HasData(
                  new Service
                  {
                      Id = 48,
                      ServiceCategoryId = salonMakeupServicesCategoryId,
                      Name = "Full makeup",
                      Name_Ku = "Full makeup",
                      Name_Ar = "مكياج سهرة/ ثقيل",
                      CreatedAt = DateTime.Now,
                      IsDeleted = false
                  },
                  new Service
                  {
                      Id = 49,
                      ServiceCategoryId = salonMakeupServicesCategoryId,
                      Name = "Simple makeup",
                      Name_Ku = "Simple makeup",
                      Name_Ar = "مكياج ناعم",
                      CreatedAt = DateTime.Now,
                      IsDeleted = false
                  },
                  new Service
                  {
                      Id = 50,
                      ServiceCategoryId = salonMakeupServicesCategoryId,
                      Name = "Brides' makeup",
                      Name_Ku = "مکیاجی بووک",
                      Name_Ar = "مكياج عروس",
                      CreatedAt = DateTime.Now,
                      IsDeleted = false
                  }
              );
            #endregion

            #region SALON-HAIR SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 51,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Keratin",
                       Name_Ku = "کیراتین",
                       Name_Ar = "كرياتين",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 52,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Mask",
                       Name_Ku = "ماسک",
                       Name_Ar = "ماسك",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 53,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Hair falling treatment",
                       Name_Ku = "چارەسەری قژ وەرین",
                       Name_Ar = "علاج تساقط الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 54,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Hair transplant",
                       Name_Ku = "چاندنی پرچ",
                       Name_Ar = "زرع الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 55,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Hair extension",
                       Name_Ku = "ئیکستێنشن",
                       Name_Ar = "إكستنشن الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 56,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Dye",
                       Name_Ku = "ڕەنگ کردن",
                       Name_Ar = "صبغ",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 57,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Hair Styling",
                       Name_Ku = "ڕازاندنەوەی قژ",
                       Name_Ar = "تسريحة شعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 58,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Hair root dye",
                       Name_Ku = "ڕەنگ کردنی ڕیشەی قژ",
                       Name_Ar = "صبغ اطراف الشعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 59,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Cutting",
                       Name_Ku = "قژ بڕین",
                       Name_Ar = "قص شعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 60,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Hairdrying",
                       Name_Ku = "سێشوار",
                       Name_Ar = "سشوار",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 61,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Acrylic/Mohair",
                       Name_Ku = "موهير",
                       Name_Ar = "موهير",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 62,
                       ServiceCategoryId = salonHairServicesCategoryId,
                       Name = "Ombre",
                       Name_Ku = "ئۆمبر",
                       Name_Ar = "اونبرة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region SALON-LASER SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 63,
                       ServiceCategoryId = salonLaserServicesCategoryId,
                       Name = "Full body",
                       Name_Ku = "تەواوی لەش",
                       Name_Ar = "كامل الجسم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 64,
                       ServiceCategoryId = salonLaserServicesCategoryId,
                       Name = "Face",
                       Name_Ku = "دەمو چاو",
                       Name_Ar = "الوجه",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region SALON-NAIL SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 65,
                       ServiceCategoryId = salonNailServicesCategoryId,
                       Name = "Manicure",
                       Name_Ku = "مانیکیور",
                       Name_Ar = "منيكير",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 66,
                       ServiceCategoryId = salonNailServicesCategoryId,
                       Name = "Pedicure",
                       Name_Ku = "پێدیکیور",
                       Name_Ar = "بديكير",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 67,
                       ServiceCategoryId = salonNailServicesCategoryId,
                       Name = "Gel",
                       Name_Ku = "جێل",
                       Name_Ar = "جلّ الأظافر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 68,
                       ServiceCategoryId = salonNailServicesCategoryId,
                       Name = "Acrylic",
                       Name_Ku = "ئاکریلیک",
                       Name_Ar = "آكريليك",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region HEALTHY-LIFE-STYLES SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 69,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Visit",
                       Name_Ku = "سەردان کردن",
                       Name_Ar = "زیارة العیادة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 70,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Diet Clinic",
                       Name_Ku = "کلینیکی پارێز کردن",
                       Name_Ar = "کلینیک نظام الغذائي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 71,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Intermittent Fasting Diet",
                       Name_Ku = "ڕێجیمی پچڕ پچڕ",
                       Name_Ar = "نطام الغذائي صوم المتقطع",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 72,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "No Deprivation Diet",
                       Name_Ku = "ڕێجیمی بێ نەقس",
                       Name_Ar = "نطام الغذائي بدون حرمان",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 73,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Lifestyle Diets",
                       Name_Ku = "ڕێجیمی شێوازی ژیان",
                       Name_Ar = "نطام الغذائي أنماط الحیاة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 74,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Atkins Diet",
                       Name_Ku = "ڕێجیمی ئاتکینز",
                       Name_Ar = "نطام الغذائي آتکینز",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 75,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Dukan Diet",
                       Name_Ku = "ڕێجیمی دوکان",
                       Name_Ar = "نطام الغذائي دوکان",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 76,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Keto Diet",
                       Name_Ku = "ڕێجیمی کیتۆ",
                       Name_Ar = "نطام الغذائي کیتو",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 77,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Ketogenic Diet Plan",
                       Name_Ku = "پلانی ڕێجیمی کیتۆجێنیک",
                       Name_Ar = "خطة نطام الغذائي کیتوجنیک",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 78,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Stevia",
                       Name_Ku = "ستێڤیا",
                       Name_Ar = "ستیڤیا",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 79,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Healthy Lifestyle",
                       Name_Ku = "شێوازی ژیانی تەندروست",
                       Name_Ar = "أنماط الحیاة صحي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 80,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Nutrition Consultation",
                       Name_Ku = "ڕاوێژی خۆراک",
                       Name_Ar = "مشاورة التغذیة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 81,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Body Composition Analyzing",
                       Name_Ku = "شیکردنەوەی پێکهاتەی لەش",
                       Name_Ar = "تحلیل ترکیب الجسم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 82,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Sugar free",
                       Name_Ku = "خاڵی لە شەکر",
                       Name_Ar = "بدون سکر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 83,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Lactose Free",
                       Name_Ku = "خاڵی لە لەکتۆز",
                       Name_Ar = "بدون لاکتوز",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 84,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Gluten Free",
                       Name_Ku = "خاڵی لە گلوتین/پێزە",
                       Name_Ar = "بدون غلوتین",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 85,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Hemiplegia treatment",
                       Name_Ku = "چارەسەری ئیفلیجی",
                       Name_Ar = "علاج فالج",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 86,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Children's hemiplegia treatment",
                       Name_Ku = "چارەسەری ئیفلیجی منداڵان",
                       Name_Ar = "علاج فالج الأطفال",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 87,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Spinal cord dislocation",
                       Name_Ku = "لە جێ دەرچوونی بڕبڕەی پشت",
                       Name_Ar = "خلع النخاع",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 88,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Joint dislocation",
                       Name_Ku = "لە جێ دەرچوونی جومگە",
                       Name_Ar = "خلع المفاصل",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 89,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Physiotherapy",
                       Name_Ku = "چارەسەری سروشتی",
                       Name_Ar = "العلاج الطبیعي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 90,
                       ServiceCategoryId = healthyLifeStyleServicesCategoryId,
                       Name = "Speaking problems",
                       Name_Ku = "گرفتەکانی قسە کردن",
                       Name_Ar = "مشاکل التکلم",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region HOME-CARE COVID SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 91,
                       ServiceCategoryId = homeCareCovidServicesCategoryId,
                       Name = "Specialist Consultation",
                       Name_Ku = "ڕاوێژكاری پزیشكی پسپۆر",
                       Name_Ar = "استشارة متخصصة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 92,
                       ServiceCategoryId = homeCareCovidServicesCategoryId,
                       Name = "24 hour Nurse Follow-Up +1 Bottle Oxigen + C-Pap",
                       Name_Ku = "چاودێری ٢٤ كاتژمێر - ستافی تایبەتمەند + ١ بتڵ ئۆكسجین + C-Pap",
                       Name_Ar = "متابعة ممرضة على مدار ٢٤ ساعة +١ زجاجة أكسجين + C-Pap",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 93,
                       ServiceCategoryId = homeCareCovidServicesCategoryId,
                       Name = "24 hour Nurse Follow-Up +1 Bottle Oxigen",
                       Name_Ku = "چاودێری ٢٤ كاتژمێر  - ستافی تایبەتمەند + ١ بتڵ ئۆكسجین",
                       Name_Ar = "متابعة ممرضة على مدار ٢٤ ساعة + ١ زجاجة أكسجين",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 94,
                       ServiceCategoryId = homeCareCovidServicesCategoryId,
                       Name = "Medication",
                       Name_Ku = "پێدانی دەرمان",
                       Name_Ar = "إعطاء الدواء",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 95,
                       ServiceCategoryId = homeCareCovidServicesCategoryId,
                       Name = "Bottle Oxygen- oxygen maker",
                       Name_Ku = "بتڵ ئۆكسجین + ئامێری ئۆكسجین",
                       Name_Ar = "زجاجة الأكسجين- صانع الأكسجين",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region HOME-CARE NORMAL-CASES SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 96,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Specialist Consultation",
                       Name_Ku = "ڕاوێژكاری پزیشكی پسپۆر",
                       Name_Ar = "استشارة متخصصة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 97,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Nurse Follow-Up By Hour",
                       Name_Ku = "چاودێری نێرس بەپێی کات",
                       Name_Ar = "متابعة الممرضة حسب الساعة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 98,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Nurse Follow-Up- 24 Hour",
                       Name_Ku = "چاودێری ٢٤ کاتژمێر",
                       Name_Ar = "متابعة الممرضة - ٢٤ ساعة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 99,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "ECG",
                       Name_Ku = "هێلكاری لێدانی دڵ",
                       Name_Ar = "تخطيط القلب الكهربائي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 100,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Insert Cannula",
                       Name_Ku = "دانانی كانولا",
                       Name_Ar = "إدراج كانولا",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 101,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Injection",
                       Name_Ku = "دەرزی لێدان",
                       Name_Ar = "حقن  ",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 102,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Foley Catheter & Remove Catheter",
                       Name_Ku = "دانانی سۆندەی میز",
                       Name_Ar = "ادراج قثطار فولي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 103,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "NG Tube",
                       Name_Ku = "دانانی سۆندەی خۆراك",
                       Name_Ar = "انبوب انفي معدي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 104,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Dressing",
                       Name_Ku = "تیماركردنی برین",
                       Name_Ar = "ضماد",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 105,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Fluid suction",
                       Name_Ku = "سۆنده‌ی کێشان",
                       Name_Ar = "شفط السوائل",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 106,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Nebulizer",
                       Name_Ku = "هەڵم",
                       Name_Ar = "بخار",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 107,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Monitoring",
                       Name_Ku = "ئامێری مۆنیتەر",
                       Name_Ar = "جهاز المراقبة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },                  
                   new Service
                   {
                       Id = 108,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "ECG Holter with Cardiologysts Report",
                       Name_Ku = "هێلكاری دڵی ٢٤ كاتژمێری لەگەڵ راپۆرتی پزیشكی پسپۆر",
                       Name_Ar = "تخطيط القلب الكهربائي مع تقرير أطباء القلب",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 109,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Fluid Aspiration",
                       Name_Ku = "دەرهێنانی ئاوی زیادەی سنگ",
                       Name_Ar = "سحب الماء من الرئة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 110,
                       ServiceCategoryId = homeCareNormalCasesServicesCategoryId,
                       Name = "Healthy Food Schedule",
                       Name_Ku = "دانانی خشتەی خۆراكی تەندروست لەلایەن پزیشكی پسپۆر",
                       Name_Ar = "جدول الغذاء الصحي",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region HOME-CARE AMBULANCE SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 111,
                       ServiceCategoryId = homeCareAmbulanceServicesCategoryId,
                       Name = "Ambulance Covid With Staff+ C-Pap + Monitor",
                       Name_Ku = "ئەمبولانس تایبەت بە توشبووی كۆڤید + ستاف + مراقبة +  C-Pap",
                       Name_Ar = "سيارة إسعاف خاص بالمشخص بكوفيد ١٩ + موظفين + C-pap",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 112,
                       ServiceCategoryId = homeCareAmbulanceServicesCategoryId,
                       Name = "Ambulance Normal Case Non-Covid",
                       Name_Ku = "ئەمبولانس - ئاسایی",
                       Name_Ar = "ئەمبوڵانس کۆڤید لەگەڵ ستاف + سی-پاپ + مۆنیتەر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 113,
                       ServiceCategoryId = homeCareAmbulanceServicesCategoryId,
                       Name = "Nurse inside Ambulance-Extra",
                       Name_Ku = "نێرس بۆ ناو ئەمبولانس",
                       Name_Ar = "ممرضة داخل الإسعاف اضافية",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }                  
               );
            #endregion

            #region HOME-CARE Physiotherapy SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 114,
                       ServiceCategoryId = homeCarePhysiotherapyServicesCategoryId,
                       Name = "Defficult Case",
                       Name_Ku = "كەیسی سەخت",
                       Name_Ar = "حالة صعبة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 115,
                       ServiceCategoryId = homeCarePhysiotherapyServicesCategoryId,
                       Name = "Chronic Case",
                       Name_Ku = "كەیسی درێژخایەن",
                       Name_Ar = "الحالة المزمنة",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 116,
                       ServiceCategoryId = homeCarePhysiotherapyServicesCategoryId,
                       Name = "Regular Case",
                       Name_Ku = "كەیسی ئاسایی",
                       Name_Ar = "حالة عادية",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region HOME-CARE Laboratory SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 117,
                       ServiceCategoryId = homeCareLaboratoryServicesCategoryId,
                       Name = "The blood will be taken in your home, and the  result will be received at home",
                       Name_Ku = "ستافی تایبەتمەند هاڵدەستێ بە وەرگرتنی خوێن لەناو ماڵەکانتان، و ئەنجامەکەی دەگەڕێتەوە بۆ ماڵەکانتان",
                       Name_Ar = "الدم سوف يؤخذ في منزلك، والنتيجة سوف تستلم في المنزل",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }                   
               );
            #endregion

            #region HOME-CARE Medicines SERVICES
            modelBuilder.Entity<Service>().HasData(
                   new Service
                   {
                       Id = 118,
                       ServiceCategoryId = homeCareMedicinesServicesCategoryId,
                       Name = "You will receive medicines recomanded by the specialists in your home",
                       Name_Ku = "ئەو دەرمانانەی کە لەلایەن پزیشکی پسپۆرەوە نوسراون، بۆتان دەگەیەنرێتە ناو ماڵەکانتان",
                       Name_Ar = "سوف تتلقى الأدوية التي يوصي بها المتخصصون في منزلك",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion

            #region BARBER SERVICES
            modelBuilder.Entity<Service>().HasData(                                
                   new Service
                   {
                       Id = 119,
                       ServiceCategoryId = barberServicesCategoryId,
                       Name = "Haircut",
                       Name_Ku = "سەر چاککردن",
                       Name_Ar = "قصة شعر",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 120,
                       ServiceCategoryId = barberServicesCategoryId,
                       Name = "Complete haircut",
                       Name_Ku = "سەرچاککردنی کامل",
                       Name_Ar = "قصة شعر کامل",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 121,
                       ServiceCategoryId = barberServicesCategoryId,
                       Name = "Groom services",
                       Name_Ku = "خزمەتگوزارییەکانی زاوا",
                       Name_Ar = "خدمات العریس",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 122,
                       ServiceCategoryId = barberServicesCategoryId,
                       Name = "Beard trimming",
                       Name_Ku = "ڕیش تاشین",
                       Name_Ar = "تقليم اللحية",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   },
                   new Service
                   {
                       Id = 123,
                       ServiceCategoryId = barberServicesCategoryId,
                       Name = "Massage",
                       Name_Ku = "مەساج",
                       Name_Ar = "تدلیک",
                       CreatedAt = DateTime.Now,
                       IsDeleted = false
                   }
               );
            #endregion
            #endregion

            modelBuilder.Entity<ScientificCategory>().HasData(
                new ScientificCategory { Id = 1, Name = "General", Name_Ku = "گشتی", Name_Ar = "عام", Description_Ku = "" },
                new ScientificCategory { Id = 2, Name = "Specialist", Name_Ku = "شارەزا", Name_Ar = "اختصاصی", Description_Ku = "" },
                new ScientificCategory { Id = 3, Name = "Expertise", Name_Ku = "ماستەر", Name_Ar = "ماجیستر", Description_Ku = "" }
            );

            int kidsExpertiseCatId = 1;
            int heartExpertiseCatId = 2;
            modelBuilder.Entity<ExpertiseCategory>().HasData(
                new ExpertiseCategory { Id = kidsExpertiseCatId, Name = "Kids", Name_Ku = "منداڵان", Name_Ar = "الأطفال", Description_Ku = "شارەزای منداڵان" },
                new ExpertiseCategory { Id = heartExpertiseCatId, Name = "Heart", Name_Ku = "دڵ", Name_Ar = "قلب", Description_Ku = "شارەزای دڵ" }
            );

            modelBuilder.Entity<Expertise>().HasData(
                new Expertise { Id = 1, Name = "Kids Specialist", Name_Ku = "شارەزای بوواری منداڵان", Name_Ar = "خبرة الأطفال", ExpertiseCategoryId = kidsExpertiseCatId, Description_Ku = "شارەزای بوواری منداڵان", CreatedAt = DateTime.Now },
                new Expertise { Id = 2, Name = "Heart Specialist", Name_Ku = "شارەزای دڵ", Name_Ar = "أخصائي القلب", ExpertiseCategoryId = heartExpertiseCatId, Description_Ku = "شارەزای دڵ", CreatedAt = DateTime.Now }
            );

            modelBuilder.Entity<Drug>().HasData(
                new Drug
                {
                    Id = 1,
                    GenericName = "Amoxil",
                    GenericName_Ar = "Amoxil",
                    GenericName_Ku = "Amoxil",
                    TradeName = "Amoxicillin"
                },
                new Drug
                {
                    Id = 2,
                    GenericName = "Neurontin",
                    GenericName_Ar = "Neurontin",
                    GenericName_Ku = "Neurontin",
                    TradeName = "Gabapentin"
                },
                new Drug
                {
                    Id = 3,
                    GenericName = "Motrin",
                    GenericName_Ar = "Motrin",
                    GenericName_Ku = "Motrin",
                    TradeName = "Ibuprofen"
                }
            );
        }
    }
}
