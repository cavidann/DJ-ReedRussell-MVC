﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dj_ReedRussel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dj_reedrussellEntities : DbContext
    {
        public dj_reedrussellEntities()
            : base("name=dj_reedrussellEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<music_types> music_types { get; set; }
        public virtual DbSet<music> musics { get; set; }
        public virtual DbSet<video_types> video_types { get; set; }
        public virtual DbSet<video> videos { get; set; }
        public virtual DbSet<album_or_radioshow> album_or_radioshow { get; set; }
        public virtual DbSet<page_name> page_name { get; set; }
        public virtual DbSet<tracklist> tracklists { get; set; }
        public virtual DbSet<myevent> myevents { get; set; }
    }
}