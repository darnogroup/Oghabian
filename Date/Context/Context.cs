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
    public class Context: IdentityDbContext<UserEntity>
    {
        public Context(DbContextOptions<Context> options) : base(options)
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.SetNull;
            }

            modelBuilder.Entity<SettingEntity>().HasKey(k => k.Id);
            modelBuilder.Entity<SeoEntity>().HasKey(k => k.SeoId);
            Configuration(modelBuilder);
            modelBuilder.HasDefaultSchema("BF");
            base.OnModelCreating(modelBuilder);
        }

        public  void Configuration(ModelBuilder builder)
        {
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
        }
    }
}
