using onlineShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using onlineShopSolution.Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace onlineShopSolution.Data.Extensions
{
    // seeding data
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "this is home page" },
              new AppConfig() { Key = "Homekeyword", Value = "this is home key word" }
          );


            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
                );



            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id=1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active
             
                },
                  new Category()
                  {
                      Id = 2,
                      IsShowOnHome = true,
                      ParentId = null,
                      SortOrder = 2,
                      Status = Status.Active
                     
              
                  }

                );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation()
                 {
                     Id=1,
                     CategoryId=1,
                     Name = "Áo nam",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-nam",
                     SeoDesciption = "Sản phẩm thời trang cho nam ",
                     SeoTitle = "Sản phẩm thời trang cho nam "
                 }, new CategoryTranslation()
                 {
                     Id=2,
                     CategoryId=1,
                     Name = "Men Shirt",
                     LanguageId = "en-US",
                     SeoAlias = "men-shirt",
                     SeoDesciption = "the shirt product for men",
                     SeoTitle = "the shirt product for men"
                 },
                   new CategoryTranslation()
                   {
                       Id=3,
                       CategoryId=2,
                       Name = "Áo nữ",
                       LanguageId = "vi-VN",
                       SeoAlias = "ao-nu",
                       SeoDesciption = "Sản phẩm thời trang cho nữ ",
                       SeoTitle = "Sản phẩm thời trang cho nữ "
                   }, new CategoryTranslation()
                   {
                       Id=4,
                       CategoryId=2,
                       Name = "Women Shirt",
                       LanguageId = "en-US",
                       SeoAlias = "women-shirt",
                       SeoDesciption = "the shirt product for women",
                       SeoTitle = "the shirt product for women"
                   }
                );

            modelBuilder.Entity<Product>().HasData(
              new Product()
              {
                  Id = 1,
                  DateCreated = DateTime.Now,
                  OriginalPrice = 150000,
                  Price = 200000,
                  ViewCount = 0,
                  Stock = 0

              }
              ) ;

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id=1,
                     ProductId = 1,
                     Name = "Áo sơ mi trắng Owen cho nam",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-so-mi-trang-owen-cho-nam",
                     SeoDesciption = "Sản phẩm thời trang cho nam 2020",
                     SeoTitle = "Sản phẩm thời trang cho nam 2020",
                     Details = "Sản phẩm bán chạy tại Owen",
                     Description = "Hàng Việt Nam xuất khẩu"
                 }, new ProductTranslation()
                 {
                     Id=2,
                     ProductId = 1,
                     Name = "T-Shirt Owen for men ",
                     LanguageId = "en-US",
                     SeoAlias = "t-shirt-owen-for-men",
                     SeoDesciption = "T-shirt product for men 2020",
                     SeoTitle = "T-shirt product for men 2020",
                     Details = "Top hot for men at Owen",
                     Description = "Made in Vietnam"
                 }) ;

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() {ProductId=1,CategoryId=1 });

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nghiepdo.dev@gmail.com",
                NormalizedEmail = "nghiepdo.dev@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "nghiepdo.dev"),
                SecurityStamp = string.Empty,
                FirstName = "Nghiep",
                LastName = "Do",
                DOB = new DateTime(1999, 12, 28)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        

    }
    }
}
