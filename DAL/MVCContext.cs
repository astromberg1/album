using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModels;

namespace DAL
    {


    public class MVCContext : DbContext
    {





        public MVCContext() : base("DestinationDB")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //            {
        //            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
        //            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


        //            // http://andreyzavadskiy.com/2016/01/12/code-first-model-conventions-something-youd-like-to-turn-off/

        //            }

        public DbSet<AlbumDataModel> Albums { get; set; }
        public DbSet<CommentsDataModel> Comments { get; set; }
        public DbSet<PhotoDataModel> Photos { get; set; }
        public DbSet<UserDataModel> Users { get; set; }

    }


        }
        



    

