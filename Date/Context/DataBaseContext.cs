using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Configuration;
using Domin.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Date.Context
{
    public class DataBaseContext: IdentityDbContext<UserEntity>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
       
        public virtual DbSet<AdsEntity>Ads { set; get; }
        public virtual DbSet<ArticleEntity>Article { set; get; }
        public virtual DbSet<CategoryEntity>Category { set; get; }
        public virtual DbSet<CommentArticleEntity>CommentArticle { set; get; }
        public virtual DbSet<CommentFoodEntity>CommentFood { set; get; }
        public virtual DbSet<FoodEntity>Food { set; get; }
        public virtual DbSet<MealEntity>Meal { set; get; }
        public virtual DbSet<PropertyEntity>Property { set; get; }
        public virtual DbSet<QuestionEntity>Question { set; get; }
        public virtual DbSet<SeoEntity>Seo { set; get; }
        public virtual DbSet<SettingEntity>Setting { set; get; }
        public virtual DbSet<SicknessEntity>Sickness { set; get; }
        public virtual DbSet<SliderEntity>Slider { set; get; }
        public virtual DbSet<AddressEntity>Address { set; get; }
        public virtual DbSet<StateEntity>State { set; get; }
        public virtual DbSet<CityEntity>City { set; get; }
        public virtual DbSet<MessageEntity>Message { set; get; }
        public virtual DbSet<SupporterEntity>Supporter { set; get; }
        public virtual DbSet<FavoriteEntity>Favorite { set; get; }
        public virtual DbSet<GalleryEntity>Gallery { set; get; }
        public virtual DbSet<MedicalInformationEntity>MedicalInformation { set; get; }
        public virtual DbSet<FoodSeoEntity>FoodSeo { set; get; }
        public virtual DbSet<ArticleSeoEntity>ArticleSeo { set; get; }
        public virtual DbSet<OrderDetailEntity>OrderDetail { set; get; }
        public virtual DbSet<OrderEntity>Order { set; get; }
        public virtual DbSet<TicketEntity>Ticket { set; get; }
        public virtual DbSet<TicketDetailEntity>TicketDetail { set; get; }
        public virtual DbSet<UserQuestionEntity>UserQuestion { set; get; }
        public virtual DbSet<UserAnswerEntity>UserAnswer { set; get; }
        public virtual DbSet<RowEntity>Row { set; get; }
        public virtual DbSet<ColumnEntity>Column { set; get; }
        public virtual DbSet<ContactEntity>Contact { set; get; }
        public virtual DbSet<MailEntity>Mail { set; get; }
        public virtual DbSet<LinkEntity>Link { set; get; }
        public virtual DbSet<DiscountEntity>Discount { set; get; }
        public virtual DbSet<ChatEntity>Chat { set; get; }
        public virtual DbSet<ChatMessageEntity>ChatMessage { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.SetNull;
            }

            modelBuilder.Entity<FoodSeoEntity>().HasKey(k => k.SeoId);
            modelBuilder.Entity<ArticleSeoEntity>().HasKey(k => k.SeoId);
            modelBuilder.Entity<SettingEntity>().HasKey(k => k.Id);
            modelBuilder.Entity<SeoEntity>().HasKey(k => k.SeoId);
            modelBuilder.Entity<ChatEntity>().HasKey(k => k.ChatId);
            Configuration(modelBuilder);
            modelBuilder.HasDefaultSchema("BF");
            base.OnModelCreating(modelBuilder);
        }

        public  void Configuration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LinkConfiguration());
            builder.ApplyConfiguration(new AdsConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CommentArticleConfiguration());
            builder.ApplyConfiguration(new CommentFoodConfiguration());
            builder.ApplyConfiguration(new FavoriteConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new MealConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());
            builder.ApplyConfiguration(new SicknessConfiguration());
            builder.ApplyConfiguration(new SliderConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new StateConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new SupporterConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MedicalInformationConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new TicketDetailConfiguration());
            builder.ApplyConfiguration(new UserQuestionConfiguration());
            builder.ApplyConfiguration(new UserAnswerConfiguration());
            builder.ApplyConfiguration(new RowConfiguration());
            builder.ApplyConfiguration(new ColumnConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new MailConfiguration());
            builder.ApplyConfiguration(new ChatMessageConfiguration());
            builder.ApplyConfiguration(new DiscountConfiguration());
        }
    }
}
