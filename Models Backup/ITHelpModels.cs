//namespace ITHelp_Models
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class ITHelpModels : DbContext
//    {
//        public ITHelpModels()
//            : base("name=ITHelpModels")
//        {
//        }

//        public virtual DbSet<Asset_Suppliers> Asset_Suppliers { get; set; }
//        public virtual DbSet<Asset_Tickets> Asset_Tickets { get; set; }
//        public virtual DbSet<Asset_Types> Asset_Types { get; set; }
//        public virtual DbSet<Asset> Assets { get; set; }
//        public virtual DbSet<Keyword> Keywords { get; set; }
//        public virtual DbSet<Knowledge> Knowledges { get; set; }
//        public virtual DbSet<Knowledge_Keywords> Knowledge_Keywords { get; set; }
//        public virtual DbSet<Location> Locations { get; set; }
//        public virtual DbSet<Ticket_History> Ticket_History { get; set; }
//        public virtual DbSet<Ticket_Keywords> Ticket_Keywords { get; set; }
//        public virtual DbSet<Ticket_Statuses> Ticket_Statuses { get; set; }
//        public virtual DbSet<Ticket_Types> Ticket_Types { get; set; }
//        public virtual DbSet<Ticket_Urgencies> Ticket_Urgencies { get; set; }
//        public virtual DbSet<Ticket> Tickets { get; set; }
//        public virtual DbSet<User> Users { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Asset_Suppliers>()
//                .HasMany(e => e.Assets)
//                .WithOptional(e => e.Asset_Suppliers)
//                .HasForeignKey(e => e.Supplier_Id);

//            modelBuilder.Entity<Asset_Types>()
//                .HasMany(e => e.Assets)
//                .WithRequired(e => e.Asset_Types)
//                .HasForeignKey(e => e.Type_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Asset>()
//                .HasMany(e => e.Asset_Tickets)
//                .WithRequired(e => e.Asset)
//                .HasForeignKey(e => e.Asset_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Keyword>()
//                .HasMany(e => e.Knowledge_Keywords)
//                .WithRequired(e => e.Keyword)
//                .HasForeignKey(e => e.Keyword_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Keyword>()
//                .HasMany(e => e.Ticket_Keywords)
//                .WithRequired(e => e.Keyword)
//                .HasForeignKey(e => e.Keyword_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Knowledge>()
//                .HasMany(e => e.Knowledge_Keywords)
//                .WithRequired(e => e.Knowledge)
//                .HasForeignKey(e => e.Knowledge_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Location>()
//                .HasMany(e => e.Assets)
//                .WithRequired(e => e.Location)
//                .HasForeignKey(e => e.Location_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket_Statuses>()
//                .HasMany(e => e.Ticket_History)
//                .WithRequired(e => e.Ticket_Statuses)
//                .HasForeignKey(e => e.Status_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket_Statuses>()
//                .HasMany(e => e.Tickets)
//                .WithRequired(e => e.Ticket_Status)
//                .HasForeignKey(e => e.Status_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket_Types>()
//                .HasMany(e => e.Tickets)
//                .WithRequired(e => e.Ticket_Type)
//                .HasForeignKey(e => e.Type_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket_Urgencies>()
//                .HasMany(e => e.Ticket_History)
//                .WithRequired(e => e.Ticket_Urgencies)
//                .HasForeignKey(e => e.Urgency_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket_Urgencies>()
//                .HasMany(e => e.Tickets)
//                .WithRequired(e => e.Ticket_Urgency)
//                .HasForeignKey(e => e.Urgency_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket>()
//                .HasMany(e => e.Ticket_History)
//                .WithRequired(e => e.Ticket)
//                .HasForeignKey(e => e.Ticket_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket>()
//                .HasMany(e => e.Ticket_Keywords)
//                .WithRequired(e => e.Ticket)
//                .HasForeignKey(e => e.Ticket_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Ticket>()
//                .HasRequired(e => e.Ticket_Status);
//        }
//    }
//}
